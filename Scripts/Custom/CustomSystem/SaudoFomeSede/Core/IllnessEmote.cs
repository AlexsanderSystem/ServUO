using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Engines.Sickness
{
	public static class IllnessEmote
	{
		// Runs animation on player
		public static void RunAnimation(ref PlayerMobile player, bool isSymptom)
		{
			(string, int) symptoms;

			if (isSymptom)
			{
				symptoms = SymptomEmote(player.Female);
			}
			else
			{
				symptoms = CureEmote(player.Female);
			}

			player.Say(symptoms.Item1);

			player.PlaySound(symptoms.Item2);

			player.Animate(RandomAnimType(), Utility.RandomMinMax(0, 1));
		}

		// Returns a tuple(string, int) emote/sound for sickness
		public static (string, int) SymptomEmote(bool isFemale)
		{
			switch (Utility.Random(20))
			{
				case 0: return ("*Dores*", isFemale ? 811 : 1085);
				case 1: return ("*Febril*", isFemale ? 795 : 1067);
				case 2: return ("*Tosse*", isFemale ? 785 : 1056);
				case 3: return ("*Espirra*", isFemale ? 817 : 1091);
				case 4: return ("*Enjoado*", isFemale ? 811 : 1085);
				case 5: return ("*Vomita*", isFemale ? 813 : 1087);
				case 6: return ("*Dor de Cabeça*", isFemale ? 811 : 1085);
				case 7: return ("*dor de estômago*", isFemale ? 811 : 1085);
				case 8: return ("*fadiga*", isFemale ? 793 : 1065);
				case 9: return ("*dor de garganta*", isFemale ? 784 : 1055);
				case 10: return ("*congestão*", isFemale ? 795 : 1067);
				case 11: return ("*doente*", isFemale ? 795 : 1067);
				case 12: return ("*nariz escorrendo*", isFemale ? 817 : 1091);
				case 13: return ("*olhos lacrimejantes*", isFemale ? 817 : 1091);
				case 14: return ("*dor de ouvido*", isFemale ? 795 : 1067);
				case 15: return ("*dor nas costas*", isFemale ? 795 : 1067);
				case 16: return ("*congestão no peito*", isFemale ? 795 : 1067);
				case 17: return ("*suores*", isFemale ? 793 : 1065);
				case 18: return ("*calafrios*", isFemale ? 795 : 1067);
				default: return ("*tonto*", isFemale ? 799 : 1071);
			}
		}

		// Returns a tuple(string, int) emote/sound for cure
		public static (string, int) CureEmote(bool isFemale)
		{
			switch (Utility.Random(20))
			{
				case 0: return ("*agradecido*", isFemale ? 783 : 1054);
				case 1: return ("*extasiado*", isFemale ? 784 : 1055);
				case 2: return ("*saudável*", isFemale ? 778 : 1051);
				case 3: return ("*milagroso*", isFemale ? 783 : 1054);
				case 4: return ("*ótimo*", isFemale ? 784 : 1055);
				case 5: return ("*grato*", isFemale ? 778 : 1051);
				case 6: return ("*abençoado*", isFemale ? 783 : 1054);
				case 7: return ("*aliviado*", isFemale ? 784 : 1055);
				case 8: return ("*radiante*", isFemale ? 778 : 1051);
				case 9: return ("*eufórico*", isFemale ? 783 : 1054);
				case 10: return ("*agradecido*", isFemale ? 784 : 1055);
				case 11: return ("*livre*", isFemale ? 778 : 1051);
				case 12: return ("*vivo*", isFemale ? 783 : 1054);
				case 13: return ("*inteiro*", isFemale ? 784 : 1055);
				case 14: return ("*renascido*", isFemale ? 778 : 1051);
				case 15: return ("*novo*", isFemale ? 783 : 1054);
				case 16: return ("*finalmente curado*", isFemale ? 784 : 1055);
				case 17: return ("*saudável novamente*", isFemale ? 778 : 1051);
				case 18: return ("*restaurado*", isFemale ? 783 : 1054);
				default: return ("*salvo*", isFemale ? 784 : 1055);
			}
		}

		// Animation types used randomly for both sickness and cures
		public static AnimationType RandomAnimType()
		{
			var animType = new List<AnimationType>()
			{
				AnimationType.Block,
				AnimationType.Impact,
				AnimationType.Eat,
				AnimationType.Emote,
				AnimationType.Parry,
				AnimationType.Die,
				AnimationType.Alert,
				AnimationType.Fidget,
				AnimationType.Spell
			};

			var rnd = Utility.RandomMinMax(0, animType.Count - 1);

			return animType[rnd];
		}
	}
}
