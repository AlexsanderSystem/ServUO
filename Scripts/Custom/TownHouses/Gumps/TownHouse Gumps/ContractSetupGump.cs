#region References
using System;
using System.Collections;

using Server;
using Server.Targeting;
#endregion

namespace Knives.TownHouses
{
	public class ContractSetupGump : GumpPlusLight
	{
		public enum Page
		{
			Blocks,
			Floors,
			Sign,
			LocSec,
			Length,
			Price
		}

		public enum TargetType
		{
			SignLoc,
			MinZ,
			MaxZ,
			BlockOne,
			BlockTwo
		}

		private readonly RentalContract c_Contract;
		private Page c_Page;

		public ContractSetupGump(Mobile m, RentalContract contract)
			: base(m, 50, 50)
		{
			m.CloseGump(typeof(ContractSetupGump));

			c_Contract = contract;
		}

		protected override void BuildGump()
		{
			var width = 300;
			var y = 0;

			switch (c_Page)
			{
				case Page.Blocks:
					BlocksPage(width, ref y);
					break;
				case Page.Floors:
					FloorsPage(width, ref y);
					break;
				case Page.Sign:
					SignPage(width, ref y);
					break;
				case Page.LocSec:
					LocSecPage(width, ref y);
					break;
				case Page.Length:
					LengthPage(width, ref y);
					break;
				case Page.Price:
					PricePage(width, ref y);
					break;
			}

			AddBackgroundZero(0, 0, width, y + 40, 0x13BE);
		}

		private void BlocksPage(int width, ref int y)
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.ShowAreaPreview(Owner);

			AddHtml(0, y += 10, width, "<CENTER>Criar a área");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			y += 25;

			if (!General.HasOtherContract(c_Contract.ParentHouse, c_Contract))
			{
				AddHtml(60, y, 90, "Casa inteira");
				AddButton(30, y, c_Contract.EntireHouse ? 0xD3 : 0xD2, "Casa inteira", EntireHouse);
			}

			if (!c_Contract.EntireHouse)
			{
				AddHtml(170, y, 70, "Adicionar Area");
				AddButton(240, y, 0x15E1, 0x15E5, "Adicionar Area", AddBlock);

				AddHtml(170, y += 20, 70, "Limpar tudo");
				AddButton(240, y, 0x15E1, 0x15E5, "Limpar tudo", ClearBlocks);
			}

			var helptext =
				String.Format(
					"   Bem-vindo ao menu de configuração do contrato de locação! Para começar, você deve " +
					"primeiro crie a área que você deseja vender. Como visto acima, existem duas maneiras de fazer isso: " +
					"alugar a casa inteira, ou partes dela. À medida que você cria a área, uma visualização simples mostra exatamente " +
					"qual área você selecionou até agora. Você pode fazer todos os tipos de formas estranhas usando várias áreas!");

			AddHtml(10, y += 35, width - 20, 170, helptext, false, false);

			y += 170;

			if (c_Contract.EntireHouse || c_Contract.Blocks.Count != 0)
			{
				AddHtml(width - 60, y += 20, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + (c_Contract.EntireHouse ? 4 : 1));
			}
		}

		private void FloorsPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Pisos");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(40, y += 25, 80, "Piso Base");
			AddButton(110, y, 0x15E1, 0x15E5, "Piso Base", MinZSelect);

			AddHtml(160, y, 80, "Último andar");
			AddButton(230, y, 0x15E1, 0x15E5, "Último andar", MaxZSelect);

			AddHtml(
				100,
				y += 25,
				100,
				String.Format(
					"{0} piso total{1}",
					c_Contract.Floors > 10 ? "1" : "" + c_Contract.Floors,
					c_Contract.Floors == 1 || c_Contract.Floors > 10 ? "" : "s"));

			var helptext =
				String.Format(
					"   Agora você precisará direcionar os andares que deseja alugar.  " +
					"Se você quiser apenas um andar, pode pular a segmentação do último andar. Tudo dentro da base " +
					"e o andar mais alto virá com o aluguel, e quanto mais andares, maior o custo posteriormente.");

			AddHtml(10, y += 35, width - 20, 120, helptext, false, false);

			y += 120;

			AddHtml(30, y += 20, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Contract.MinZ != short.MinValue)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void SignPage(int width, ref int y)
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.ShowSignPreview();

			AddHtml(0, y += 10, width, "<CENTER>A localização da Placa");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(100, y += 25, 80, "Defina localização");
			AddButton(180, y, 0x15E1, 0x15E5, "Localização da Placa", SignLocSelect);

			var helptext =
				String.Format(
					"   Com este sinal, o locatário terá todos os poderes que um proprietário tem " +
					"sobre a área deles. Se eles usarem esse poder para demolir sua unidade alugada, eles quebraram seu " +
					"contrato e não receberá seu depósito de segurança. Eles também podem bani-lo de sua casa alugada!");

			AddHtml(10, y += 35, width - 20, 110, helptext, false, false);

			y += 110;

			AddHtml(30, y += 20, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Contract.SignLoc != Point3D.Zero)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void LocSecPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Bloqueios e Seguranças");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Sugerir segurança");
			AddButton(width / 2 - 70, y + 3, 0x2716, "Sugerir LocSec", SuggestLocSec);
			AddButton(width / 2 + 60, y + 3, 0x2716, "Sugerir LocSec", SuggestLocSec);

			AddHtml(
				30,
				y += 25,
				width / 2 - 20,
				"<DIV ALIGN=RIGHT>Seguros (Max: " + (General.RemainingSecures(c_Contract.ParentHouse) + c_Contract.Secures) + ")");
			AddTextField(width / 2 + 50, y, 50, 20, 0x480, 0xBBC, "Seguros", c_Contract.Secures.ToString());
			AddButton(width / 2 + 25, y + 3, 0x2716, "Seguros", Secures);

			AddHtml(
				30,
				y += 20,
				width / 2 - 20,
				"<DIV ALIGN=RIGHT>Fechaduras (Max: " + (General.RemainingLocks(c_Contract.ParentHouse) + c_Contract.Locks) + ")");
			AddTextField(width / 2 + 50, y, 50, 20, 0x480, 0xBBC, "Fechaduras", c_Contract.Locks.ToString());
			AddButton(width / 2 + 25, y + 3, 0x2716, "Fechaduras", Lockdowns);

			var helptext =
				String.Format(
					"   Sem dar arrumação, isto não seria bem uma casa! Aqui você lhes dá bloqueios " +
					"e protege de sua própria casa. Use o botão de sugestões para ter uma ideia de quanto você deve doar. Tenha muito cuidado quando " +
					"alugando sua propriedade: se você usa muito armazenamento, começa a usar o armazenamento que reservou para seus clientes.  " +
					"Você receberá um aviso de 48 horas quando isso acontecer, mas depois disso o contrato desaparece!");

			AddHtml(10, y += 35, width - 20, 180, helptext, false, false);

			y += 180;

			AddHtml(30, y += 20, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Contract.Locks != 0 && c_Contract.Secures != 0)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void LengthPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Periodo de Aluguel");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(120, y += 25, 50, c_Contract.PriceType);
			AddButton(170, y + 8, 0x985, "Comprimento Acima", LengthUp);
			AddButton(170, y - 2, 0x983, "comprimento para baixo", LengthDown);

			var helptext =
				String.Format(
					"   A cada {0} o banco transferirá automaticamente o custo do aluguel deles para você.  " +
					"Ao usar as setas, você pode percorrer outros períodos de tempo para algo que atenda melhor às suas necessidades.",
					c_Contract.PriceTypeShort.ToLower());

			AddHtml(10, y += 35, width - 20, 100, helptext, false, false);

			y += 100;

			AddHtml(30, y += 20, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - (c_Contract.EntireHouse ? 4 : 1));

			AddHtml(width - 60, y, 60, "Proximo");
			AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
		}

		private void PricePage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Cobrança por período");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Livre");
			AddButton(width / 2 - 80, y, c_Contract.Free ? 0xD3 : 0xD2, "Livre", Free);
			AddButton(width / 2 + 60, y, c_Contract.Free ? 0xD3 : 0xD2, "Livre", Free);

			if (!c_Contract.Free)
			{
				AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Por " + c_Contract.PriceTypeShort);
				AddTextField(width / 2 + 20, y, 70, 20, 0x480, 0xBBC, "Preço", c_Contract.Price.ToString());
				AddButton(width / 2 - 5, y + 3, 0x2716, "Preço", Price);

				AddHtml(0, y += 20, width, "<CENTER>Sugestão");
				AddButton(width / 2 - 70, y + 3, 0x2716, "Sugestão", SuggestPrice);
				AddButton(width / 2 + 60, y + 3, 0x2716, "Sugestão", SuggestPrice);
			}

			var helptext =
				String.Format(
					"   Agora você pode finalizar o contrato incluindo seu preço por {0}.  " +
					"Depois de finalizar, a única maneira de modificá-lo é descartá-lo e iniciar um novo contrato! Por " +
					"usando o botão de sugestão, um preço será calculado automaticamente com base no seguinte:<BR>",
					c_Contract.PriceTypeShort);

			helptext += String.Format("<CENTER>Volume: {0}<BR>", c_Contract.CalcVolume());
			helptext += String.Format("Custo por unidade: {0} ouro</CENTER>", General.SuggestionFactor);
			helptext += "<br>   Você também pode doar este espaço gratuitamente usando a opção acima.";

			AddHtml(10, y += 35, width - 20, 150, helptext, false, true);

			y += 150;

			AddHtml(30, y += 20, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Contract.Price != 0)
			{
				AddHtml(width - 70, y, 60, "Finalizar");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Finalizar", FinalizeSetup);
			}
		}

		protected override void OnClose()
		{
			c_Contract.ClearPreview();
		}

		private void SuggestPrice()
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.Price = c_Contract.CalcVolume() * General.SuggestionFactor;

			if (c_Contract.RentByTime == TimeSpan.FromDays(1))
			{
				c_Contract.Price /= 60;
			}
			if (c_Contract.RentByTime == TimeSpan.FromDays(7))
			{
				c_Contract.Price = (int)(c_Contract.Price / 8.57);
			}
			if (c_Contract.RentByTime == TimeSpan.FromDays(30))
			{
				c_Contract.Price /= 2;
			}

			NewGump();
		}

		private void SuggestLocSec()
		{
			var price = c_Contract.CalcVolume() * General.SuggestionFactor;
			c_Contract.Secures = price / 75;
			c_Contract.Locks = c_Contract.Secures / 2;

			c_Contract.FixLocSec();

			NewGump();
		}

		private void Price()
		{
			c_Contract.Price = GetTextFieldInt("Preço");
			Owner.SendMessage("Price set!");
			NewGump();
		}

		private void Secures()
		{
			c_Contract.Secures = GetTextFieldInt("Seguros");
			Owner.SendMessage("Seguros Definidos!");
			NewGump();
		}

		private void Lockdowns()
		{
			c_Contract.Locks = GetTextFieldInt("Fechaduras");
			Owner.SendMessage("Fechaduras Definidas!");
			NewGump();
		}

		private void ChangePage(object obj)
		{
			if (c_Contract == null || !(obj is int))
			{
				return;
			}

			c_Contract.ClearPreview();

			c_Page = (Page)(int)obj;

			NewGump();
		}

		private void EntireHouse()
		{
			if (c_Contract == null || c_Contract.ParentHouse == null)
			{
				return;
			}

			c_Contract.EntireHouse = !c_Contract.EntireHouse;

			c_Contract.ClearPreview();

			if (c_Contract.EntireHouse)
			{
				var list = new ArrayList();

				var once = false;
				foreach (var rect in RUOVersion.RegionArea(c_Contract.ParentHouse.Region))
				{
					list.Add(new Rectangle2D(new Point2D(rect.Start.X, rect.Start.Y), new Point2D(rect.End.X, rect.End.Y)));

					if (once)
					{
						continue;
					}

					if (rect.Start.Z >= rect.End.Z)
					{
						c_Contract.MinZ = rect.End.Z;
						c_Contract.MaxZ = rect.Start.Z;
					}
					else
					{
						c_Contract.MinZ = rect.Start.Z;
						c_Contract.MaxZ = rect.End.Z;
					}

					once = true;
				}

				c_Contract.Blocks = list;
			}
			else
			{
				c_Contract.Blocks.Clear();
				c_Contract.MinZ = short.MinValue;
				c_Contract.MaxZ = short.MinValue;
			}

			NewGump();
		}

		private void SignLocSelect()
		{
			Owner.Target = new InternalTarget(this, c_Contract, TargetType.SignLoc);
		}

		private void MinZSelect()
		{
			Owner.SendMessage("Direcione o piso base para sua área de aluguel.");
			Owner.Target = new InternalTarget(this, c_Contract, TargetType.MinZ);
		}

		private void MaxZSelect()
		{
			Owner.SendMessage("Selecione o andar mais alto para sua área de aluguel.");
			Owner.Target = new InternalTarget(this, c_Contract, TargetType.MaxZ);
		}

		private void LengthUp()
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.NextPriceType();

			if (c_Contract.RentByTime == TimeSpan.FromDays(0))
			{
				c_Contract.RentByTime = TimeSpan.FromDays(1);
			}

			NewGump();
		}

		private void LengthDown()
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.PrevPriceType();

			if (c_Contract.RentByTime == TimeSpan.FromDays(0))
			{
				c_Contract.RentByTime = TimeSpan.FromDays(30);
			}

			NewGump();
		}

		private void Free()
		{
			c_Contract.Free = !c_Contract.Free;

			NewGump();
		}

		private void AddBlock()
		{
			Owner.SendMessage("Mire no canto noroeste.");
			Owner.Target = new InternalTarget(this, c_Contract, TargetType.BlockOne);
		}

		private void ClearBlocks()
		{
			if (c_Contract == null)
			{
				return;
			}

			c_Contract.Blocks.Clear();

			c_Contract.ClearPreview();

			NewGump();
		}

		private void FinalizeSetup()
		{
			if (c_Contract == null)
			{
				return;
			}

			if (c_Contract.Price == 0)
			{
				Owner.SendMessage("Você não pode alugar a área por 0 ouro!");
				NewGump();
				return;
			}

			c_Contract.Completed = true;
			c_Contract.BanLoc = c_Contract.ParentHouse.Region.GoLocation;

			if (c_Contract.EntireHouse)
			{
				var point = c_Contract.ParentHouse.Sign.Location;
				c_Contract.SignLoc = new Point3D(point.X, point.Y, point.Z - 5);
				c_Contract.Secures = Core.AOS ? c_Contract.ParentHouse.GetAosMaxSecures() : c_Contract.ParentHouse.MaxSecures;
				c_Contract.Locks = Core.AOS ? c_Contract.ParentHouse.GetAosMaxLockdowns() : c_Contract.ParentHouse.MaxLockDowns;
			}

			Owner.SendMessage("Você finalizou este contrato de locação. Agora encontre alguém para assiná-lo!");
		}

		private class InternalTarget : Target
		{
			private readonly ContractSetupGump c_Gump;
			private readonly RentalContract c_Contract;
			private readonly TargetType c_Type;
			private readonly Point3D c_BoundOne;

			public InternalTarget(ContractSetupGump gump, RentalContract contract, TargetType type)
				: this(gump, contract, type, Point3D.Zero)
			{ }

			public InternalTarget(ContractSetupGump gump, RentalContract contract, TargetType type, Point3D point)
				: base(20, true, TargetFlags.None)
			{
				c_Gump = gump;
				c_Contract = contract;
				c_Type = type;
				c_BoundOne = point;
			}

			protected override void OnTarget(Mobile m, object o)
			{
				var point = (IPoint3D)o;

				if (c_Contract == null || c_Contract.ParentHouse == null)
				{
					return;
				}

				if (!c_Contract.ParentHouse.Region.Contains(new Point3D(point.X, point.Y, point.Z)))
				{
					m.SendMessage("Você deve segmentar dentro de casa.");
					m.Target = new InternalTarget(c_Gump, c_Contract, c_Type, c_BoundOne);
					return;
				}

				switch (c_Type)
				{
					case TargetType.SignLoc:
						c_Contract.SignLoc = new Point3D(point.X, point.Y, point.Z);
						c_Contract.ShowSignPreview();
						c_Gump.NewGump();
						break;

					case TargetType.MinZ:
						if (!c_Contract.ParentHouse.Region.Contains(new Point3D(point.X, point.Y, point.Z)))
						{
							m.SendMessage("Isso não está dentro de sua casa.");
						}
						else if (c_Contract.HasContractedArea(point.Z))
						{
							m.SendMessage("Essa área já está ocupada por outro contrato de locação.");
						}
						else
						{
							c_Contract.MinZ = point.Z;

							if (c_Contract.MaxZ < c_Contract.MinZ + 19)
							{
								c_Contract.MaxZ = point.Z + 19;
							}
						}

						c_Contract.ShowFloorsPreview(m);
						c_Gump.NewGump();
						break;

					case TargetType.MaxZ:
						if (!c_Contract.ParentHouse.Region.Contains(new Point3D(point.X, point.Y, point.Z)))
						{
							m.SendMessage("Isso não está dentro de sua casa.");
						}
						else if (c_Contract.HasContractedArea(point.Z))
						{
							m.SendMessage("Essa área já está ocupada por outro contrato de locação.");
						}
						else
						{
							c_Contract.MaxZ = point.Z + 19;

							if (c_Contract.MinZ > c_Contract.MaxZ)
							{
								c_Contract.MinZ = point.Z;
							}
						}

						c_Contract.ShowFloorsPreview(m);
						c_Gump.NewGump();
						break;

					case TargetType.BlockOne:
						m.SendMessage("Agora mire no canto sudeste.");
						m.Target = new InternalTarget(c_Gump, c_Contract, TargetType.BlockTwo, new Point3D(point.X, point.Y, point.Z));
						break;

					case TargetType.BlockTwo:
						var rect = TownHouseSetupGump.FixRect(new Rectangle2D(c_BoundOne, new Point3D(point.X + 1, point.Y + 1, point.Z)));

						if (c_Contract.HasContractedArea(rect, point.Z))
						{
							m.SendMessage("Essa área já está ocupada por outro contrato de locação.jn  ");
						}
						else
						{
							c_Contract.Blocks.Add(rect);
							c_Contract.ShowAreaPreview(m);
						}

						c_Gump.NewGump();
						break;
				}
			}

			protected override void OnTargetCancel(Mobile m, TargetCancelType cancelType)
			{
				c_Gump.NewGump();
			}
		}
	}
}