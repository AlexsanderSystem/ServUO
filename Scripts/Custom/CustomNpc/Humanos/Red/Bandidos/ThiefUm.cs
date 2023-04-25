using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Ladrao")]
    public class LadraoUM : BaseCreature
    {
        [Constructable]
        public LadraoUM()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
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
            SetHits(160, 180);

            SetDamage(10, 23);

            SetSkill(SkillName.Fencing, 50.0, 70.0);
            SetSkill(SkillName.Macing, 50.0, 70.0);
            SetSkill(SkillName.MagicResist, 50.0, 70.0);
            SetSkill(SkillName.Swords, 50.0, 70.0);
            SetSkill(SkillName.Tactics, 50.0, 70.0);
            SetSkill(SkillName.Wrestling, 50.0, 70.0);
            SetSkill(SkillName.Archery, 50.0, 70.0);


            Fame = 300;
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

        private double _movementSpeed = 2.0;

            public double MovementSpeed
            {
                get { return _movementSpeed; }
                set { _movementSpeed = value; }
            }

            public override void OnThink()
            {
                this.ActiveSpeed = _movementSpeed;
                base.OnThink();
            }


        public LadraoUM(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => true;
        public override bool AlwaysMurderer => true;

        public override bool ShowFameTitle => false;

		private static readonly Type[] _WeaponsList =
		{
			typeof(Longsword), typeof(Cutlass), typeof(Broadsword), typeof(Club), typeof(Dagger),
		};

		private static readonly Type[] _LootList =
		{
			typeof(Cloak), typeof(Robe), typeof(Cap),
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
