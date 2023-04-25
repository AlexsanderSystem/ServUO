using System;
using System.Linq;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
	public class LockpickingGump : BaseGump
	{
		private const int PinUpId = 116;
		private const int PinDownId = 115;
		private const int LockpickId = 114;

		private const int PinWidth = 520;
		private const int PinHeight = 65;
		private const int LockpickWidth = 52;
		private const int LockpickHeight = 184;

		private const int MaxPins = 10;
		private const int MinPins = 3;

		private int PinsToPick;
		private int[] PressedPins;
		private int[] Combination;
		private int CurrentPinIndex;

		private ILockpickable Lpable;
		private Lockpick Lpick;

		public LockpickingGump(PlayerMobile pm, ILockpickable lpable, Lockpick lp)
			: base(pm)
		{
			Lpable = lpable;
			Lpick = lp;
			double requiredSkill = lpable.RequiredSkill;
			double lockpickSkill = pm.Skills[SkillName.Lockpicking].Value;
			PinsToPick = MinPins + (int)Math.Max(0, Math.Floor((1 - lockpickSkill / requiredSkill) * (MaxPins - MinPins)));

			int i;
			Combination = new int[10];
			PressedPins = new int[10]; 

			Random rnd = new Random();
			for (i = 0; i < Combination.Length; i++)
				Combination[i] = i+1;

			Combination = Combination.OrderBy(x => rnd.Next()).ToArray();

			for (i = 0; i < 10 - PinsToPick; i++)
				PressedPins[i] = Combination[i];

			CurrentPinIndex = i;

			AddGumpLayout();
		}

		public override void AddGumpLayout()
		{
			User.CloseGump(this.GetType());

			if (!Lpable.Locked)
			{
				User.SendMessage("This lock is already unlocked.");
				return;
			}

			int borders = 16;
			int title = 0;

			AddBackground(0, 0, PinWidth + 2 * borders, PinHeight + LockpickHeight + 2 * borders + title, 2620);

			int i = 0;

			for (i = 1; i <= 10 ; i++)
			{
				if (PressedPins.Contains(i))
					AddButton((i - 1) * LockpickWidth + borders, borders + title, PinUpId, PinUpId, i, GumpButtonType.Reply, 0);
				else
					AddButton((i - 1) * LockpickWidth + borders, borders + title, PinDownId, PinDownId, i, GumpButtonType.Reply, 0);
			}

			AddImage(borders, borders + title + LockpickHeight, LockpickId, 0);
		}

		public override void OnResponse(RelayInfo info)
		{
			Item lpable = Lpable as Item;
			if(lpable == null || lpable.Deleted || !lpable.IsAccessibleTo(User) || !lpable.InRange(User.Location, 1))
			{
				this.Close();
				return;
			}

			int id = info.ButtonID;

			if (id == 0)
			{
				this.Close();
				return;
			}

			if (!PressedPins.Contains(id))
			{
				if (Lpick.Amount < 1)
				{
					User.SendMessage("You are out of lockpicks!");
					this.Close();
					return;
				}

				int rnd = Utility.Random(4);

				if (rnd == 0)
				{
					User.PlaySound(0x3A4);
					Lpick.Consume();
				}
				else
					User.PlaySound(0x3B9 + rnd);

				PressedPins[CurrentPinIndex] = id;
				CurrentPinIndex++;
			}

			if (CurrentPinIndex >= 10)
			{
				User.PlaySound(0x241);
				Timer.DelayCall(TimeSpan.FromMilliseconds(500.0), CheckCombination);
			}
			
			Refresh();
		}

		public void CheckCombination()
		{
			if (Combination.SequenceEqual(PressedPins))
			{
				User.PlaySound(0x0EA);
				Lpable.LockPick(User);
				User.SendMessage("You successfully pick the lock!");				
				this.Close();
			}
			else //retry
			{
				int i;
				PressedPins = new int[10];
				User.SendMessage("You failed to pick the lock.");
				for (i = 0; i < 10 - PinsToPick; ++i)
					PressedPins[i] = Combination[i];
				CurrentPinIndex = i;
				Refresh();
			}
		}
	}
}