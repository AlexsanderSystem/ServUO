using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Ladrao")]
    public class LadraoDois : BaseCreature
    {
        [Constructable]
        public LadraoDois()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            SpeechHue = Utility.RandomDyedHue();
            Title = "O Ladrao";
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

            SetStr(86, 100);
            SetDex(81, 95);
            SetInt(61, 75);

            SetDamage(10, 23);

            SetSkill(SkillName.Fencing, 66.0, 97.5);
            SetSkill(SkillName.Macing, 65.0, 87.5);
            SetSkill(SkillName.MagicResist, 25.0, 47.5);
            SetSkill(SkillName.Swords, 65.0, 87.5);
            SetSkill(SkillName.Tactics, 65.0, 87.5);
            SetSkill(SkillName.Wrestling, 15.0, 37.5);
            SetSkill(SkillName.Archery, 80.0, 100.0);
            SetSkill(SkillName.Tactics, 80.0, 100.0);

            Fame = 1000;
            Karma = -1000;

            SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new LeatherChest(), dropChance: 1);
			SetWearable(new LeatherGloves(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new LeatherGorget(), Utility.RandomNeutralHue(), dropChance: 1);
			SetWearable(new Cap(), dropChance: 1);

			SetWearable((Item)Activator.CreateInstance(Utility.RandomList(_WeaponsList)), dropChance: 1);
			SetWearable(new Cloak(), Utility.RandomNeutralHue(), dropChance: 1);

			SetWearable((Item)Activator.CreateInstance(Utility.RandomList(_LootList)), dropChance: 1);

            Utility.AssignRandomHair(this);
        }

        public LadraoDois(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override bool AlwaysMurderer => true;

        public override bool ShowFameTitle => false;

		private static readonly Type[] _WeaponsList =
		{
			typeof(Bow),
		};

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
