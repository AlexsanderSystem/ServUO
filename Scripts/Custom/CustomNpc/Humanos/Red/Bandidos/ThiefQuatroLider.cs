using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Lider Bandido")]
    public class LiderBandido : BaseCreature
    {
        [Constructable]
        public LiderBandido()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SpeechHue = Utility.RandomDyedHue();
            Title = "O Lider";
            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
                SetWearable(new Skirt(), Utility.RandomNeutralHue(), dropChance: 1);
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                SetWearable(new ShortPants(), Utility.RandomNeutralHue(), dropChance: 1);
            }

            SetStr(200, 250);
            SetDex(100, 125);
            SetInt(50, 75);

            SetDamage(20, 35);

            SetSkill(SkillName.Fencing, 120.0, 140.0);
            SetSkill(SkillName.Macing, 110.0, 120.0);
            SetSkill(SkillName.MagicResist, 70.0, 90.0);
            SetSkill(SkillName.Swords, 120.0, 140.0);
            SetSkill(SkillName.Tactics, 120.0, 140.0);
            SetSkill(SkillName.Wrestling, 70.0, 90.0);
            SetSkill(SkillName.Archery, 80.0, 100.0);

            Fame = 10000;
            Karma = -10000;

            SetWearable(new PlateChest(), Utility.RandomNeutralHue(), dropChance: 0.25);
			SetWearable(new PlateGloves(), Utility.RandomNeutralHue(), dropChance: 0.25);
			SetWearable(new PlateGorget(), Utility.RandomNeutralHue(), dropChance: 0.25);
			SetWearable(new PlateLegs(), Utility.RandomNeutralHue(), dropChance: 0.25);
			SetWearable(new PlateArms(), Utility.RandomNeutralHue(), dropChance: 0.25);
			SetWearable(new Helmet(), Utility.RandomNeutralHue(), dropChance: 0.25);

            SetWearable((Item)Activator.CreateInstance(typeof(ExecutionersAxe)), dropChance: 1);

			SetWearable((Item)Activator.CreateInstance(typeof(PoisonedDagger)), dropChance: 0.05);


            Utility.AssignRandomHair(this);
        }

        public LiderBandido(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override bool AlwaysMurderer => true;

        public override bool ShowFameTitle => false;

		private static readonly Type[] _LootList =
		{
			typeof(Cloak), typeof(Robe), typeof(Scimitar), typeof(Cap), typeof(Bow),
			typeof(Lockpick), typeof(Gold)
        };

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
