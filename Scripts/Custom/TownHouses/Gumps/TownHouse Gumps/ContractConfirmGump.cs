#region References
using System;

using Server;
#endregion

namespace Knives.TownHouses
{
	public class ContractConfirmGump : GumpPlusLight
	{
		private readonly RentalContract c_Contract;

		public ContractConfirmGump(Mobile m, RentalContract rc)
			: base(m, 100, 100)
		{
			m.CloseGump(typeof(ContractConfirmGump));

			c_Contract = rc;
		}

		protected override void BuildGump()
		{
			var width = 300;
			var y = 0;

			if (c_Contract.RentalClient == null)
			{
				AddHtml(0, y + 5, width, HTML.Black + "<CENTER>Alugar essa casa?");
			}
			else
			{
				AddHtml(0, y + 5, width, HTML.Black + "<CENTER>Contrato de Locação");
			}

			var text =
				String.Format(
					"Eu, {0}, concordo em alugar esta propriedade de {1} pelo valor de {2} a cada {3}. " +
					"Os fundos para este pagamento serão retirados diretamente da minha conta bancária. No caso em que " +
					"eu não possa pagar esta taxa, a propriedade retornará para {1}. Eu posso cancelar este acordo a qualquer momento " +
					"demolindo a propriedade. {1} também pode cancelar este acordo a qualquer momento, demolindo sua " +
					"propriedade ou cancelando o contrato, neste caso, seu depósito de segurança será devolvido.",

					c_Contract.RentalClient == null ? "_____" : c_Contract.RentalClient.Name,
					c_Contract.RentalMaster.Name,
					c_Contract.Free ? 0 : c_Contract.Price,
					c_Contract.PriceTypeShort.ToLower());

			text += "<BR>   Here is some more info reguarding this property:<BR>";

			text += String.Format("<CENTER>Lockdowns: {0}<BR>", c_Contract.Locks);
			text += String.Format("Proteções: {0}<BR>", c_Contract.Secures);
			text += String.Format(
				"Andares: {0}<BR>",
				(c_Contract.MaxZ - c_Contract.MinZ < 200) ? (c_Contract.MaxZ - c_Contract.MinZ) / 20 + 1 : 1);
			text += String.Format("Espaço: {0} unidades cúbicas,", c_Contract.CalcVolume());

			AddHtml(40, y += 30, width - 60, 200, HTML.Black + text, false, true);

			y += 200;

			if (c_Contract.RentalClient == null)
			{
				AddHtml(60, y += 20, 60, HTML.Black + "Visualizar");
				AddButton(40, y + 3, 0x837, 0x838, "Visualizar", Preview);

				var locsec = c_Contract.ValidateLocSec();

				if (Owner != c_Contract.RentalMaster && locsec)
				{
					AddHtml(width - 100, y, 60, HTML.Black + "Aceitar");
					AddButton(width - 60, y + 3, 0x232C, 0x232D, "Aceitar", Accept);
				}
				else
				{
					AddImage(width - 60, y - 10, 0x232C);
				}

				if (!locsec)
				{
					Owner.SendMessage(
						(Owner == c_Contract.RentalMaster
						? "Você não tem as quantidades de Lockdowns ou Secures necessárias para este contrato."
						: "O proprietário deste contrato não pode alugar esta propriedade no momento."));
				}
			}
			else
			{
				if (Owner == c_Contract.RentalMaster)
				{
					AddHtml(60, y += 20, 100, HTML.Black + "Cancelar Contrato");
					AddButton(40, y + 3, 0x837, 0x838, "Cancelar Contrato", CancelContract);
				}
				else
				{
					AddImage(width - 60, y += 20, 0x232C);
				}
			}

			AddBackgroundZero(0, 0, width, y + 23, 0x24A4);
		}

		protected override void OnClose()
		{
			c_Contract.ClearPreview();
		}

		private void Preview()
		{
			c_Contract.ShowAreaPreview(Owner);
			NewGump();
		}

		private void CancelContract()
		{
			if (Owner == c_Contract.RentalClient)
			{
				c_Contract.House.Delete();
			}
			else
			{
				c_Contract.Delete();
			}
		}

		private void Accept()
		{
			if (!c_Contract.ValidateLocSec())
			{
				Owner.SendMessage("O proprietário deste contrato não pode alugar esta propriedade no momento.");
				return;
			}

			c_Contract.Purchase(Owner);

			if (!c_Contract.Owned)
			{
				return;
			}

			c_Contract.Visible = true;
			c_Contract.RentalClient = Owner;
			c_Contract.RentalClient.AddToBackpack(new RentalContractCopy(c_Contract));
		}
	}
}