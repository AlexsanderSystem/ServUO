#region References
using System;

using Server;
using Server.Targeting;
#endregion

namespace Knives.TownHouses
{
	public class TownHouseSetupGump : GumpPlusLight
	{
		public static Rectangle2D FixRect(Rectangle2D rect)
		{
			var pointOne = Point3D.Zero;
			var pointTwo = Point3D.Zero;

			if (rect.Start.X < rect.End.X)
			{
				pointOne.X = rect.Start.X;
				pointTwo.X = rect.End.X;
			}
			else
			{
				pointOne.X = rect.End.X;
				pointTwo.X = rect.Start.X;
			}

			if (rect.Start.Y < rect.End.Y)
			{
				pointOne.Y = rect.Start.Y;
				pointTwo.Y = rect.End.Y;
			}
			else
			{
				pointOne.Y = rect.End.Y;
				pointTwo.Y = rect.Start.Y;
			}

			return new Rectangle2D(pointOne, pointTwo);
		}

		public enum Page
		{
			Welcome,
			Blocks,
			Floors,
			Sign,
			Ban,
			LocSec,
			Items,
			Length,
			Price,
			Skills,
			Other,
			Other2
		}

		public enum TargetType
		{
			BanLoc,
			SignLoc,
			MinZ,
			MaxZ,
			BlockOne,
			BlockTwo
		}

		private readonly TownHouseSign c_Sign;
		private Page c_Page;
		private bool c_Quick;

		public TownHouseSetupGump(Mobile m, TownHouseSign sign)
			: base(m, 50, 50)
		{
			m.CloseGump(typeof(TownHouseSetupGump));

			c_Sign = sign;
		}

		protected override void BuildGump()
		{
			if (c_Sign == null)
			{
				return;
			}

			var width = 300;
			var y = 0;

			if (c_Quick)
			{
				QuickPage(width, ref y);
			}
			else
			{
				switch (c_Page)
				{
					case Page.Welcome:
						WelcomePage(width, ref y);
						break;
					case Page.Blocks:
						BlocksPage(width, ref y);
						break;
					case Page.Floors:
						FloorsPage(width, ref y);
						break;
					case Page.Sign:
						SignPage(width, ref y);
						break;
					case Page.Ban:
						BanPage(width, ref y);
						break;
					case Page.LocSec:
						LocSecPage(width, ref y);
						break;
					case Page.Items:
						ItemsPage(width, ref y);
						break;
					case Page.Length:
						LengthPage(width, ref y);
						break;
					case Page.Price:
						PricePage(width, ref y);
						break;
					case Page.Skills:
						SkillsPage(width, ref y);
						break;
					case Page.Other:
						OtherPage(width, ref y);
						break;
					case Page.Other2:
						OtherPage2(width, ref y);
						break;
				}

				BuildTabs(width, ref y);
			}

			AddBackgroundZero(0, 0, width, y += 30, 0x13BE);

			if (c_Sign.PriceReady && !c_Sign.Owned)
			{
				AddBackground(width / 2 - 50, y, 100, 30, 0x13BE);
				AddHtml(width / 2 - 50 + 25, y + 5, 100, "Deixar Residência");
				AddButton(width / 2 - 50 + 5, y + 10, 0x837, 0x838, "Alegar", Claim);
			}
		}

		private void BuildTabs(int width, ref int y)
		{
			var x = 20;

			y += 30;

			AddButton(x - 5, y - 3, 0x768, "Rápida", Quick);
			AddLabel(x, y - 3, c_Quick ? 0x34 : 0x47E, "Q");

			AddButton(x += 20, y, c_Page == Page.Welcome ? 0x939 : 0x93A, "Página de boas-vindas", ChangePage, 0);
			AddButton(x += 20, y, c_Page == Page.Blocks ? 0x939 : 0x93A, "Página de bloqueios", ChangePage, 1);

			if (c_Sign.BlocksReady)
			{
				AddButton(x += 20, y, c_Page == Page.Floors ? 0x939 : 0x93A, "Pagina Pisos", ChangePage, 2);
			}

			if (c_Sign.FloorsReady)
			{
				AddButton(x += 20, y, c_Page == Page.Sign ? 0x939 : 0x93A, "Placa de assinatura", ChangePage, 3);
			}

			if (c_Sign.SignReady)
			{
				AddButton(x += 20, y, c_Page == Page.Ban ? 0x939 : 0x93A, "Página de banimento", ChangePage, 4);
			}

			if (c_Sign.BanReady)
			{
				AddButton(x += 20, y, c_Page == Page.LocSec ? 0x939 : 0x93A, "Página LocSec", ChangePage, 5);
			}

			if (c_Sign.LocSecReady)
			{
				AddButton(x += 20, y, c_Page == Page.Items ? 0x939 : 0x93A, "Página de itens", ChangePage, 6);

				if (!c_Sign.Owned)
				{
					AddButton(x += 20, y, c_Page == Page.Length ? 0x939 : 0x93A, "Página de comprimento", ChangePage, 7);
				}
				else
				{
					x += 20;
				}

				AddButton(x += 20, y, c_Page == Page.Price ? 0x939 : 0x93A, "Página de preço", ChangePage, 8);
			}

			if (c_Sign.PriceReady)
			{
				AddButton(x += 20, y, c_Page == Page.Skills ? 0x939 : 0x93A, "Página de Habilidades", ChangePage, 9);
				AddButton(x += 20, y, c_Page == Page.Other ? 0x939 : 0x93A, "Outra página", ChangePage, 10);
				AddButton(x += 20, y, c_Page == Page.Other2 ? 0x939 : 0x93A, "Outra página 2", ChangePage, 11);
			}
		}

		private void QuickPage(int width, ref int y)
		{
			c_Sign.ClearPreview();

			AddHtml(0, y += 10, width, "<CENTER>Configuração Rápida");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddButton(5, 5, 0x768, "Rápida", Quick);
			AddLabel(10, 5, c_Quick ? 0x34 : 0x47E, "Q");

			AddHtml(0, y += 25, width / 2 - 55, "<DIV ALIGN=RIGHT>Nome");
			AddTextField(width / 2 - 15, y, 100, 20, 0x480, 0xBBC, "Nome", c_Sign.Name);
			AddButton(width / 2 - 40, y + 3, 0x2716, "Nome", Name);

			AddHtml(0, y += 25, width / 2, "<CENTER>Adicionar área");
			AddButton(width / 4 - 50, y + 3, 0x2716, "Adicionar área", AddBlock);
			AddButton(width / 4 + 40, y + 3, 0x2716, "Adicionar área", AddBlock);

			AddHtml(width / 2, y, width / 2, "<CENTER>Limpar tudo");
			AddButton(width / 4 * 3 - 50, y + 3, 0x2716, "Limpar tudo", ClearAll);
			AddButton(width / 4 * 3 + 40, y + 3, 0x2716, "Limpar tudo", ClearAll);

			AddHtml(0, y += 25, width, "<CENTER>Piso Base: " + c_Sign.MinZ);
			AddButton(width / 2 - 80, y + 3, 0x2716, "Piso Base", MinZSelect);
			AddButton(width / 2 + 70, y + 3, 0x2716, "Piso Base", MinZSelect);

			AddHtml(0, y += 17, width, "<CENTER>Último andar: " + c_Sign.MaxZ);
			AddButton(width / 2 - 80, y + 3, 0x2716, "Último andar", MaxZSelect);
			AddButton(width / 2 + 70, y + 3, 0x2716, "Último andar", MaxZSelect);

			AddHtml(0, y += 25, width / 2, "<CENTER>Placa Loc");
			AddButton(width / 4 - 50, y + 3, 0x2716, "Placa Loc", SignLocSelect);
			AddButton(width / 4 + 40, y + 3, 0x2716, "Placa Loc", SignLocSelect);

			AddHtml(width / 2, y, width / 2, "<CENTER>Banir Loc");
			AddButton(width / 4 * 3 - 50, y + 3, 0x2716, "Banir Loc", BanLocSelect);
			AddButton(width / 4 * 3 + 40, y + 3, 0x2716, "Banir Loc", BanLocSelect);

			AddHtml(0, y += 25, width, "<CENTER>Sugestão Seguros");
			AddButton(width / 2 - 70, y + 3, 0x2716, "Sugestão LocSec", SuggestLocSec);
			AddButton(width / 2 + 60, y + 3, 0x2716, "Sugestão LocSec", SuggestLocSec);

			AddHtml(0, y += 20, width / 2 - 20, "<DIV ALIGN=RIGHT>Seguros");
			AddTextField(width / 2 + 20, y, 50, 20, 0x480, 0xBBC, "Seguros", c_Sign.Secures.ToString());
			AddButton(width / 2 - 5, y + 3, 0x2716, "Seguros", Secures);

			AddHtml(0, y += 22, width / 2 - 20, "<DIV ALIGN=RIGHT>Fechaduras");
			AddTextField(width / 2 + 20, y, 50, 20, 0x480, 0xBBC, "Fechaduras", c_Sign.Locks.ToString());
			AddButton(width / 2 - 5, y + 3, 0x2716, "Fechaduras", Lockdowns);

			AddHtml(0, y += 25, width, "<CENTER>Dê itens ao comprador em casa");
			AddButton(width / 2 - 110, y, c_Sign.KeepItems ? 0xD3 : 0xD2, "manter itens", KeepItems);
			AddButton(width / 2 + 90, y, c_Sign.KeepItems ? 0xD3 : 0xD2, "manter itens", KeepItems);

			if (c_Sign.KeepItems)
			{
				AddHtml(0, y += 25, width / 2 - 25, "<DIV ALIGN=RIGHT>Ao custo");
				AddTextField(width / 2 + 15, y, 70, 20, 0x480, 0xBBC, "Itens Preço", c_Sign.ItemsPrice.ToString());
				AddButton(width / 2 - 10, y + 5, 0x2716, "Itens Preço", ItemsPrice);
			}
			else
			{
				AddHtml(0, y += 25, width, "<CENTER>Não exclua itens");
				AddButton(width / 2 - 110, y, c_Sign.LeaveItems ? 0xD3 : 0xD2, "Deixar itens", LeaveItems);
				AddButton(width / 2 + 90, y, c_Sign.LeaveItems ? 0xD3 : 0xD2, "Deixar itens", LeaveItems);
			}

			if (!c_Sign.Owned)
			{
				AddHtml(120, y += 25, 50, c_Sign.PriceType);
				AddButton(170, y + 8, 0x985, 0x985, "Comprimento Acima", PriceUp);
				AddButton(170, y - 2, 0x983, 0x983, "comprimento para baixo", PriceDown);
			}

			if (c_Sign.RentByTime != TimeSpan.Zero)
			{
				AddHtml(0, y += 25, width, "<CENTER>Aluguel recorrente");
				AddButton(width / 2 - 80, y, c_Sign.RecurRent ? 0xD3 : 0xD2, "Aluguel recorrente", RecurRent);
				AddButton(width / 2 + 60, y, c_Sign.RecurRent ? 0xD3 : 0xD2, "Aluguel recorrente", RecurRent);

				if (c_Sign.RecurRent)
				{
					AddHtml(0, y += 20, width, "<CENTER>Alugar para possuir");
					AddButton(width / 2 - 80, y, c_Sign.RentToOwn ? 0xD3 : 0xD2, "Alugar para possuir", RentToOwn);
					AddButton(width / 2 + 60, y, c_Sign.RentToOwn ? 0xD3 : 0xD2, "Alugar para possuir", RentToOwn);
				}
			}

			AddHtml(0, y += 25, width, "<CENTER>FGratisree");
			AddButton(width / 2 - 80, y, c_Sign.Free ? 0xD3 : 0xD2, "FrGratisee", Free);
			AddButton(width / 2 + 60, y, c_Sign.Free ? 0xD3 : 0xD2, "Gratis", Free);

			if (!c_Sign.Free)
			{
				AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>" + c_Sign.PriceType + " Preços");
				AddTextField(width / 2 + 20, y, 70, 20, 0x480, 0xBBC, "Preços", c_Sign.Price.ToString());
				AddButton(width / 2 - 5, y + 5, 0x2716, "Preços", Price);

				AddHtml(0, y += 25, width, "<CENTER>Sugestão de Preços");
				AddButton(width / 2 - 70, y + 3, 0x2716, "Sugestão", SuggestPrice);
				AddButton(width / 2 + 50, y + 3, 0x2716, "Sugestão", SuggestPrice);
			}
		}

		private void WelcomePage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Bem-vindo!");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			var helptext = "";

			AddHtml(0, y += 25, width / 2 - 55, "<DIV ALIGN=RIGHT>Nome");
			AddTextField(width / 2 - 15, y, 100, 20, 0x480, 0xBBC, "Nome", c_Sign.Name);
			AddButton(width / 2 - 40, y + 3, 0x2716, "Nome", Name);

			if (c_Sign != null && c_Sign.Map != Map.Internal && c_Sign.RootParent == null)
			{
				AddHtml(0, y += 25, width, "<CENTER>Vá para");
				AddButton(width / 2 - 50, y + 3, 0x2716, "Vá para", Goto);
				AddButton(width / 2 + 40, y + 3, 0x2716, "Vá para", Goto);
			}

			if (c_Sign.Owned)
			{
				helptext =
					String.Format(
						"  Esta casa pertence a {0}, portanto, esteja ciente de que mudar qualquer coisa " +
						"através deste menu mudará a própria casa! Você pode adicionar mais área, alterar a propriedade" +
						"regras, quase tudo! Você não pode, no entanto, alterar o status de aluguel da casa, demais " +
						"maneiras de as coisas correrem mal. Se você alterar as restrições e o dono da casa não as atender mais, " +
						"eles receberão o aviso normal de demolição de 24 horas.",
						c_Sign.House.Owner.Name);

				AddHtml(10, y += 25, width - 20, 180, helptext, false, false);

				y += 180;
			}
			else
			{
				helptext =
					String.Format(
						"  Bem-vindo ao menu de configuração do TownHouse! Este menu irá guiá-lo através de " +
						"cada etapa do processo de configuração. Você pode configurar qualquer área para ser uma casa e, em seguida, detalhar tudo, desde " +
						"bloqueios e preço para vender ou alugar a casa. Vamos começar aqui com o nome de " +
						"esta nova Casa da Cidade!");

				AddHtml(10, y += 25, width - 20, 130, helptext, false, false);

				y += 130;
			}

			AddHtml(width - 60, y += 15, 60, "Proximo");
			AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
		}

		private void BlocksPage(int width, ref int y)
		{
			if (c_Sign == null)
			{
				return;
			}

			c_Sign.ShowAreaPreview(Owner);

			AddHtml(0, y += 10, width, "<CENTER>Criar a área");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>AAdicionar área");
			AddButton(width / 2 - 50, y + 3, 0x2716, "Adicionar área", AddBlock);
			AddButton(width / 2 + 40, y + 3, 0x2716, "Adicionar área", AddBlock);

			AddHtml(0, y += 20, width, "<CENTER>Limpar tudo");
			AddButton(width / 2 - 50, y + 3, 0x2716, "Limpar tudo", ClearAll);
			AddButton(width / 2 + 40, y + 3, 0x2716, "Limpar tudo", ClearAll);

			var helptext =
				String.Format(
					"   A configuração começa com a definição da área que você deseja vender ou alugar. " +
					"Você pode adicionar quantas caixas quiser e, a cada vez, a visualização se estenderá para mostrar o que " +
					"você selecionou até agora. Se você quiser começar de novo, apenas limpe-os! Você deve ter " +
					"pelo menos um bloco definido antes de prosseguir para a etapa Proximo.");

			AddHtml(10, y += 35, width - 20, 140, helptext, false, false);

			y += 140;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.BlocksReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void FloorsPage(int width, ref int y)
		{
			c_Sign.ShowFloorsPreview(Owner);

			AddHtml(0, y += 10, width, "<CENTER>Base");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Piso Base: " + c_Sign.MinZ);
			AddButton(width / 2 - 80, y + 3, 0x2716, "Piso Base", MinZSelect);
			AddButton(width / 2 + 70, y + 3, 0x2716, "Piso Base", MinZSelect);

			AddHtml(0, y += 20, width, "<CENTER>Último andar: " + c_Sign.MaxZ);
			AddButton(width / 2 - 80, y + 3, 0x2716, "Último andar", MaxZSelect);
			AddButton(width / 2 + 70, y + 3, 0x2716, "Último andar", MaxZSelect);

			var helptext =
				String.Format(
					"   Agora você precisará segmentar os andares que deseja vender. " +
					"Se você quiser apenas um andar, pode pular o último andar. Tudo dentro da base " +
					"e o andar mais alto virá com a casa, e quanto mais andares, maior o custo mais tarde.");

			AddHtml(10, y += 35, width - 20, 110, helptext, false, false);

			y += 110;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.FloorsReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void SignPage(int width, ref int y)
		{
			if (c_Sign == null)
			{
				return;
			}

			c_Sign.ShowSignPreview();

			AddHtml(0, y += 10, width, "<CENTER>Localização da Placa");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Defina localização");
			AddButton(width / 2 - 60, y + 3, 0x2716, "Placa Loc", SignLocSelect);
			AddButton(width / 2 + 50, y + 3, 0x2716, "Placa Loc", SignLocSelect);

			var helptext =
				String.Format(
					"   Com este sinal, o proprietário terá os mesmos direitos de propriedade da casa" +
					"como casas personalizadas ou clássicas. Se eles usarem a placa para demolir a casa, isso será feito automaticamente " +
					"voltar para venda ou aluguel. O sinal que os jogadores usarão para comprar a casa aparecerá no mesmo " +
					"mancha, ligeiramente abaixo do sinal normal da casa.");

			AddHtml(10, y += 35, width - 20, 130, helptext, false, false);

			y += 130;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.SignReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void BanPage(int width, ref int y)
		{
			if (c_Sign == null)
			{
				return;
			}

			c_Sign.ShowBanPreview();

			AddHtml(0, y += 10, width, "<CENTER>Localização da proibição");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Defina localização");
			AddButton(width / 2 - 60, y + 3, 0x2716, "Ban Loc", BanLocSelect);
			AddButton(width / 2 + 50, y + 3, 0x2716, "Ban Loc", BanLocSelect);

			var helptext =
				String.Format(
					"   O local do banimento determina para onde os jogadores são enviados quando expulsos ou " +
					"banido de uma casa. Se você nunca definir isso, eles aparecerão no canto sudoeste do lado de fora" +
					"da casa.");

			AddHtml(10, y += 35, width - 20, 100, helptext, false, false);

			y += 100;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.BanReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void LocSecPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Fechaduras e Seguranças");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Sugestão");
			AddButton(width / 2 - 50, y + 3, 0x2716, "Sugestão LocSec", SuggestLocSec);
			AddButton(width / 2 + 40, y + 3, 0x2716, "Sugestão LocSec", SuggestLocSec);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Seguros");
			AddTextField(width / 2 + 20, y, 50, 20, 0x480, 0xBBC, "Seguros", c_Sign.Secures.ToString());
			AddButton(width / 2 - 5, y + 3, 0x2716, "Seguros", Secures);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Fechaduras");
			AddTextField(width / 2 + 20, y, 50, 20, 0x480, 0xBBC, "Fechaduras", c_Sign.Locks.ToString());
			AddButton(width / 2 - 5, y + 3, 0x2716, "Fechaduras", Lockdowns);

			var helptext =
				String.Format(
					" Com esta etapa, você definirá a quantidade de armazenamento para a casa ou deixará " +
					"o sistema faz isso para você usando o botão Sugerir. Em geral, os jogadores recebem metade do número de bloqueios" +
					"como armazenamento seguro.");

			AddHtml(10, y += 35, width - 20, 90, helptext, false, false);

			y += 90;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.LocSecReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void ItemsPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Artigos de decoração");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Dê itens ao comprador em casa");
			AddButton(width / 2 - 110, y, c_Sign.KeepItems ? 0xD3 : 0xD2, "manter itens", KeepItems);
			AddButton(width / 2 + 90, y, c_Sign.KeepItems ? 0xD3 : 0xD2, "manter itens", KeepItems);

			if (c_Sign.KeepItems)
			{
				AddHtml(0, y += 25, width / 2 - 25, "<DIV ALIGN=RIGHT>Ao custo");
				AddTextField(width / 2 + 15, y, 70, 20, 0x480, 0xBBC, "Itens Preço", c_Sign.ItemsPrice.ToString());
				AddButton(width / 2 - 10, y + 5, 0x2716, "Itens Preço", ItemsPrice);
			}
			else
			{
				AddHtml(0, y += 25, width, "<CENTER>Não exclua itens");
				AddButton(width / 2 - 110, y, c_Sign.LeaveItems ? 0xD3 : 0xD2, "Deixar itens", LeaveItems);
				AddButton(width / 2 + 90, y, c_Sign.LeaveItems ? 0xD3 : 0xD2, "Deixar itens", LeaveItems);
			}

			var helptext =
				String.Format(
				   " Por padrão, o sistema excluirá todos os itens não estáticos já " +
				   "na casa no momento da compra. Esses itens são comumente referidos como itens de decoração. " +
				   "Eles não incluem complementos domésticos, como forjas e similares. Eles incluem contêineres. Você pode " +
				   "Permita que os jogadores mantenham esses itens dizendo isso aqui, e você também pode cobrá-los!");

			AddHtml(10, y += 35, width - 20, 160, helptext, false, false);

			y += 160;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.ItemsReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + (c_Sign.Owned ? 2 : 1));
			}
		}

		private void LengthPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Comprar ou Alugar");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(120, y += 25, 50, c_Sign.PriceType);
			AddButton(170, y + 8, 0x985, 0x985, "Comprimento Acima", PriceUp);
			AddButton(170, y - 2, 0x983, 0x983, "comprimento para baixo", PriceDown);

			if (c_Sign.RentByTime != TimeSpan.Zero)
			{
				AddHtml(0, y += 25, width, "<CENTER>Aluguel recorrente");
				AddButton(width / 2 - 80, y, c_Sign.RecurRent ? 0xD3 : 0xD2, "Recorrente", RecurRent);
				AddButton(width / 2 + 60, y, c_Sign.RecurRent ? 0xD3 : 0xD2, "Recorrente", RecurRent);

				if (c_Sign.RecurRent)
				{
					AddHtml(0, y += 20, width, "<CENTER>Alugar para possuir");
					AddButton(width / 2 - 80, y, c_Sign.RentToOwn ? 0xD3 : 0xD2, "Alugar para possuir", RentToOwn);
					AddButton(width / 2 + 60, y, c_Sign.RentToOwn ? 0xD3 : 0xD2, "Alugar para possuir", RentToOwn);
				}
			}

			var helptext =
				String.Format(
					"   Cada vez mais perto de concluir o setup! Agora você pode especificar se " +
					"este é um imóvel de compra ou aluguel. Basta usar as setas até ter a configuração que deseja. Para " +
					"imovel alugado, voce tambem pode fazer a compra nao recorrente, ou seja, apos o tempo acabar o player" +
					"pega o chute! Com recorrente, se eles tiverem o dinheiro disponível, eles podem continuar alugando. Você pode " +
					"também permite Alugar para possuir, permitindo que os jogadores possuam a propriedade depois de fazer dois meses de pagamentos.");

			AddHtml(10, y += 35, width - 20, 160, helptext, false, true);

			y += 160;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.LengthReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void PricePage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Preço");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Gratis");
			AddButton(width / 2 - 80, y, c_Sign.Free ? 0xD3 : 0xD2, "Gratis", Free);
			AddButton(width / 2 + 60, y, c_Sign.Free ? 0xD3 : 0xD2, "Gratis", Free);

			if (!c_Sign.Free)
			{
				AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>" + c_Sign.PriceType + " Preço");
				AddTextField(width / 2 + 20, y, 70, 20, 0x480, 0xBBC, "Preço", c_Sign.Price.ToString());
				AddButton(width / 2 - 5, y + 5, 0x2716, "Price", Price);

				AddHtml(0, y += 20, width, "<CENTER>sugerir");
				AddButton(width / 2 - 50, y + 3, 0x2716, "sugerir", SuggestPrice);
				AddButton(width / 2 + 40, y + 3, 0x2716, "sugerir", SuggestPrice);
			}

			var helptext =
				String.Format(
					"   Agora você pode definir o preço da casa. Lembre-se, se isso for um " +
					"casa alugada, o sistema vai cobrar esse valor a cada período! Felizmente a Sugestão " +
					"leva isso em consideração. Se você não quiser adivinhar, deixe o sistema sugerir um preço para você. " +
					"Você também pode dar a casa com a opção Grátis.");

			AddHtml(10, y += 35, width - 20, 130, helptext, false, false);

			y += 130;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - (c_Sign.Owned ? 2 : 1));

			if (c_Sign.PriceReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void SkillsPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Restrições de habilidades");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Skill");
			AddTextField(width / 2 + 20, y, 100, 20, 0x480, 0xBBC, "Habilidades", c_Sign.Skill);
			AddButton(width / 2 - 5, y + 5, 0x2716, "Skill", Skill);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Amount");
			AddTextField(width / 2 + 20, y, 50, 20, 0x480, 0xBBC, "Habilidades requeridas", c_Sign.SkillReq.ToString());
			AddButton(width / 2 - 5, y + 5, 0x2716, "Skill", Skill);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Min Total");
			AddTextField(width / 2 + 20, y, 60, 20, 0x480, 0xBBC, "Minimo Total de Habilidade", c_Sign.MinTotalSkill.ToString());
			AddButton(width / 2 - 5, y + 5, 0x2716, "Skill", Skill);

			AddHtml(0, y += 25, width / 2 - 20, "<DIV ALIGN=RIGHT>Max Total");
			AddTextField(width / 2 + 20, y, 60, 20, 0x480, 0xBBC, "Maximo Total de Habilidade", c_Sign.MaxTotalSkill.ToString());
			AddButton(width / 2 - 5, y + 5, 0x2716, "Habilidade", Skill);

			var helptext =
				String.Format(
					"   Essas configurações são todas opcionais. Se você quiser restringir quem pode possuir " +
					"esta casa por suas habilidades, aqui é o lugar. Você pode especificar pelo nome e valor da habilidade, ou por " +
					"habilidades totais do jogador.");

			AddHtml(10, y += 35, width - 20, 90, helptext, false, false);

			y += 90;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			if (c_Sign.PriceReady)
			{
				AddHtml(width - 60, y, 60, "Proximo");
				AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
			}
		}

		private void OtherPage(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Outras opções");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Jovens");
			AddButton(width / 2 - 80, y, c_Sign.YoungOnly ? 0xD3 : 0xD2, "Somente Jovens", Young);
			AddButton(width / 2 + 60, y, c_Sign.YoungOnly ? 0xD3 : 0xD2, "Somente Jovens", Young);

			if (!c_Sign.YoungOnly)
			{
				AddHtml(0, y += 25, width, "<CENTER>Inocentes");
				AddButton(width / 2 - 80, y, c_Sign.Murderers == Intu.No ? 0xD3 : 0xD2, "Sem Assassinos", Murderers, Intu.No);
				AddButton(width / 2 + 60, y, c_Sign.Murderers == Intu.No ? 0xD3 : 0xD2, "Sem Assassinos", Murderers, Intu.No);
				AddHtml(0, y += 20, width, "<CENTER>Assassinos");
				AddButton(width / 2 - 80, y, c_Sign.Murderers == Intu.Yes ? 0xD3 : 0xD2, "Sim Assassinos", Murderers, Intu.Yes);
				AddButton(width / 2 + 60, y, c_Sign.Murderers == Intu.Yes ? 0xD3 : 0xD2, "Sim Assassinos", Murderers, Intu.Yes);
				AddHtml(0, y += 20, width, "<CENTER>Todos");
				AddButton(
					width / 2 - 80,
					y,
					c_Sign.Murderers == Intu.Neither ? 0xD3 : 0xD2,
					"Nem assassinos",
					Murderers,
					Intu.Neither);
				AddButton(
					width / 2 + 60,
					y,
					c_Sign.Murderers == Intu.Neither ? 0xD3 : 0xD2,
					"Nem assassinos",
					Murderers,
					Intu.Neither);
			}

			AddHtml(0, y += 25, width, "<CENTER>Retranque as portas ao demolir");
			AddButton(width / 2 - 110, y, c_Sign.Relock ? 0xD3 : 0xD2, "Rebloquear", Relock);
			AddButton(width / 2 + 90, y, c_Sign.Relock ? 0xD3 : 0xD2, "Rebloquear", Relock);

			var helptext =
				String.Format(
					"   Essas opções também são opcionais. Com a configuração jovem, você pode restringir " +
					"que pode comprar a casa apenas para jogadores jovens. Da mesma forma, você pode especificar se assassinos ou inocentes são " +
					" permissão para possuir a casa. Você também pode especificar se as portas dentro do " +
					"casa estão trancadas quando o proprietário demoliu sua propriedade.");

			AddHtml(10, y += 35, width - 20, 180, helptext, false, false);

			y += 180;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);

			AddHtml(width - 60, y, 60, "Proximo");
			AddButton(width - 30, y, 0x15E1, 0x15E5, "Proximo", ChangePage, (int)c_Page + 1);
		}

		private void OtherPage2(int width, ref int y)
		{
			AddHtml(0, y += 10, width, "<CENTER>Outras opções 2");
			AddImage(width / 2 - 100, y + 2, 0x39);
			AddImage(width / 2 + 70, y + 2, 0x3B);

			AddHtml(0, y += 25, width, "<CENTER>Forçar pública");
			AddButton(width / 2 - 110, y, c_Sign.ForcePublic ? 0xD3 : 0xD2, "pública", ForcePublic);
			AddButton(width / 2 + 90, y, c_Sign.ForcePublic ? 0xD3 : 0xD2, "pública", ForcePublic);

			AddHtml(0, y += 25, width, "<CENTER>Forçar Privado");
			AddButton(width / 2 - 110, y, c_Sign.ForcePrivate ? 0xD3 : 0xD2, "Privado", ForcePrivate);
			AddButton(width / 2 + 90, y, c_Sign.ForcePrivate ? 0xD3 : 0xD2, "Privado", ForcePrivate);

			AddHtml(0, y += 25, width, "<CENTER>Sem Negociação");
			AddButton(width / 2 - 110, y, c_Sign.NoTrade ? 0xD3 : 0xD2, "NoTrade", NoTrade);
			AddButton(width / 2 + 90, y, c_Sign.NoTrade ? 0xD3 : 0xD2, "NoTrade", NoTrade);

			AddHtml(0, y += 25, width, "<CENTER>Sem Banimento");
			AddButton(width / 2 - 110, y, c_Sign.NoBanning ? 0xD3 : 0xD2, "NoBan", NoBan);
			AddButton(width / 2 + 90, y, c_Sign.NoBanning ? 0xD3 : 0xD2, "NoBan", NoBan);

			var helptext =
				String.Format(
					"   Outra página de opções opcionais! Às vezes, as casas têm recursos que você não deseja que os jogadores usem.  " +
					"Então aqui você pode forçar as casas a serem privadas ou públicas. Você também pode impedir a negociação da casa. Por fim, você pode remover a capacidade de banir jogadores.");

			AddHtml(10, y += 35, width - 20, 180, helptext, false, false);

			y += 180;

			AddHtml(30, y += 15, 80, "Anterior");
			AddButton(10, y, 0x15E3, 0x15E7, "Anterior", ChangePage, (int)c_Page - 1);
		}

		private bool SkillNameExists(string text)
		{
			try
			{
				var index = (SkillName)Enum.Parse(typeof(SkillName), text, true);
				return true;
			}
			catch
			{
				Owner.SendMessage("Você forneceu um nome de habilidade inválido.");
				return false;
			}
		}

		private void ChangePage(object obj)
		{
			if (c_Sign == null)
			{
				return;
			}

			if (!(obj is int))
			{
				return;
			}

			c_Page = (Page)(int)obj;

			c_Sign.ClearPreview();

			NewGump();
		}

		private void Name()
		{
			c_Sign.Name = GetTextField("Nomes");
			Owner.SendMessage("Conjunto de nomes!");
			NewGump();
		}

		private void Goto()
		{
			Owner.Location = c_Sign.Location;
			Owner.Z += 5;
			Owner.Map = c_Sign.Map;

			NewGump();
		}

		private void Quick()
		{
			c_Quick = !c_Quick;
			NewGump();
		}

		private void BanLocSelect()
		{
			Owner.SendMessage("Alveje o local da proibição.");
			Owner.Target = new InternalTarget(this, c_Sign, TargetType.BanLoc);
		}

		private void SignLocSelect()
		{
			Owner.SendMessage("Alveje o local para a placa de casa.");
			Owner.Target = new InternalTarget(this, c_Sign, TargetType.SignLoc);
		}

		private void MinZSelect()
		{
			Owner.SendMessage("Alveje o piso base.");
			Owner.Target = new InternalTarget(this, c_Sign, TargetType.MinZ);
		}

		private void MaxZSelect()
		{
			Owner.SendMessage("Mire no andar mais alto.");
			Owner.Target = new InternalTarget(this, c_Sign, TargetType.MaxZ);
		}

		private void Young()
		{
			c_Sign.YoungOnly = !c_Sign.YoungOnly;
			NewGump();
		}

		private void Murderers(object obj)
		{
			if (!(obj is Intu))
			{
				return;
			}

			c_Sign.Murderers = (Intu)obj;

			NewGump();
		}

		private void Relock()
		{
			c_Sign.Relock = !c_Sign.Relock;
			NewGump();
		}

		private void ForcePrivate()
		{
			c_Sign.ForcePrivate = !c_Sign.ForcePrivate;
			NewGump();
		}

		private void ForcePublic()
		{
			c_Sign.ForcePublic = !c_Sign.ForcePublic;
			NewGump();
		}

		private void NoTrade()
		{
			c_Sign.NoTrade = !c_Sign.NoTrade;
			NewGump();
		}

		private void NoBan()
		{
			c_Sign.NoBanning = !c_Sign.NoBanning;
			NewGump();
		}

		private void KeepItems()
		{
			c_Sign.KeepItems = !c_Sign.KeepItems;
			NewGump();
		}

		private void LeaveItems()
		{
			c_Sign.LeaveItems = !c_Sign.LeaveItems;
			NewGump();
		}

		private void ItemsPrice()
		{
			c_Sign.ItemsPrice = GetTextFieldInt("Itens Preço");
			Owner.SendMessage("Preço do item definido!");
			NewGump();
		}

		private void RecurRent()
		{
			c_Sign.RecurRent = !c_Sign.RecurRent;
			NewGump();
		}

		private void RentToOwn()
		{
			c_Sign.RentToOwn = !c_Sign.RentToOwn;
			NewGump();
		}

		private void Skill()
		{
			if (GetTextField("habilidade") != "" && SkillNameExists(GetTextField("habilidade")))
			{
				c_Sign.Skill = GetTextField("habilidade");
			}
			else
			{
				c_Sign.Skill = "";
			}

			c_Sign.SkillReq = GetTextFieldInt("Requisitos de habilidade");
			c_Sign.MinTotalSkill = GetTextFieldInt("Habilidade total mínima");
			c_Sign.MaxTotalSkill = GetTextFieldInt("Habilidade total máxima");

			Owner.SendMessage("Conjunto de informações de habilidade!");

			NewGump();
		}

		private void Claim()
		{
			new TownHouseConfirmGump(Owner, c_Sign);
			OnClose();
		}

		private void SuggestLocSec()
		{
			var price = c_Sign.CalcVolume() * General.SuggestionFactor;
			c_Sign.Secures = price / 75;
			c_Sign.Locks = c_Sign.Secures / 2;

			NewGump();
		}

		private void Secures()
		{
			c_Sign.Secures = GetTextFieldInt("Seguros");
			Owner.SendMessage("conjunto de segurança!");
			NewGump();
		}

		private void Lockdowns()
		{
			c_Sign.Locks = GetTextFieldInt("Fechaduras");
			Owner.SendMessage("Fechaduras definida!");
			NewGump();
		}

		private void SuggestPrice()
		{
			c_Sign.Price = c_Sign.CalcVolume() * General.SuggestionFactor;

			if (c_Sign.RentByTime == TimeSpan.FromDays(1))
			{
				c_Sign.Price /= 60;
			}
			if (c_Sign.RentByTime == TimeSpan.FromDays(7))
			{
				c_Sign.Price = (int)(c_Sign.Price / 8.57);
			}
			if (c_Sign.RentByTime == TimeSpan.FromDays(30))
			{
				c_Sign.Price /= 2;
			}

			NewGump();
		}

		private void Price()
		{
			c_Sign.Price = GetTextFieldInt("Preço");
			Owner.SendMessage("Conjunto de preços!");
			NewGump();
		}

		private void Free()
		{
			c_Sign.Free = !c_Sign.Free;
			NewGump();
		}

		private void AddBlock()
		{
			if (c_Sign == null)
			{
				return;
			}

			Owner.SendMessage("Mire no canto noroeste.");
			Owner.Target = new InternalTarget(this, c_Sign, TargetType.BlockOne);
		}

		private void ClearAll()
		{
			if (c_Sign == null)
			{
				return;
			}

			c_Sign.Blocks.Clear();
			c_Sign.ClearPreview();
			c_Sign.UpdateBlocks();

			NewGump();
		}

		private void PriceUp()
		{
			c_Sign.NextPriceType();
			NewGump();
		}

		private void PriceDown()
		{
			c_Sign.PrevPriceType();
			NewGump();
		}

		protected override void OnClose()
		{
			c_Sign.ClearPreview();
		}

		private class InternalTarget : Target
		{
			private readonly TownHouseSetupGump c_Gump;
			private readonly TownHouseSign c_Sign;
			private readonly TargetType c_Type;
			private readonly Point3D c_BoundOne;

			public InternalTarget(TownHouseSetupGump gump, TownHouseSign sign, TargetType type)
				: this(gump, sign, type, Point3D.Zero)
			{ }

			public InternalTarget(TownHouseSetupGump gump, TownHouseSign sign, TargetType type, Point3D point)
				: base(20, true, TargetFlags.None)
			{
				c_Gump = gump;
				c_Sign = sign;
				c_Type = type;
				c_BoundOne = point;
			}

			protected override void OnTarget(Mobile m, object o)
			{
				var point = (IPoint3D)o;

				switch (c_Type)
				{
					case TargetType.BanLoc:
						c_Sign.BanLoc = new Point3D(point.X, point.Y, point.Z);
						c_Gump.NewGump();
						break;

					case TargetType.SignLoc:
						c_Sign.SignLoc = new Point3D(point.X, point.Y, point.Z);
						c_Sign.MoveToWorld(c_Sign.SignLoc, c_Sign.Map);
						c_Sign.Z -= 5;
						c_Sign.ShowSignPreview();
						c_Gump.NewGump();
						break;

					case TargetType.MinZ:
						c_Sign.MinZ = point.Z;

						if (c_Sign.MaxZ < c_Sign.MinZ + 19)
						{
							c_Sign.MaxZ = point.Z + 19;
						}

						if (c_Sign.MaxZ == short.MaxValue)
						{
							c_Sign.MaxZ = point.Z + 19;
						}

						c_Gump.NewGump();
						break;

					case TargetType.MaxZ:
						c_Sign.MaxZ = point.Z + 19;

						if (c_Sign.MinZ > c_Sign.MaxZ)
						{
							c_Sign.MinZ = point.Z;
						}

						c_Gump.NewGump();
						break;

					case TargetType.BlockOne:
						m.SendMessage("Agora mire no canto sudeste.");
						m.Target = new InternalTarget(c_Gump, c_Sign, TargetType.BlockTwo, new Point3D(point.X, point.Y, point.Z));
						break;

					case TargetType.BlockTwo:
						c_Sign.Blocks.Add(FixRect(new Rectangle2D(c_BoundOne, new Point3D(point.X + 1, point.Y + 1, point.Z))));
						c_Sign.UpdateBlocks();
						c_Sign.ShowAreaPreview(m);
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