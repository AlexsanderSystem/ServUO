﻿using Server.Mobiles;

namespace Server.Engines.Sickness.Mobiles
{
	[CorpseName("a infected rat corpse")]

	public class InfectedRat : InfectedMobile
	{
		[Constructable]
		public InfectedRat() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a infected rat";
			Body = 0xD7;
			BaseSoundID = 0x188;

			Hue = 1175;

			SetStr(59);
			SetDex(51);
			SetInt(17);

			SetHits(92);
			SetMana(0);

			SetDamage(4, 8);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 35, 40);
			SetResistance(ResistanceType.Fire, 20, 25);
			SetResistance(ResistanceType.Cold, 25, 35);
			SetResistance(ResistanceType.Energy, 35, 40);

			SetSkill(SkillName.MagicResist, 25.1, 30.0);
			SetSkill(SkillName.Tactics, 34.5, 40.0);
			SetSkill(SkillName.Wrestling, 40.5, 45.0);

			Fame = 300;
			Karma = -300;
		}

		public InfectedRat(Serial serial) : base(serial)
		{
		}

		public override int Meat => 1;

		public override int Hides => 6;

		public override FoodType FavoriteFood => FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs;

		// Sickness props
		public override bool IsActiveOnGaveMelee => true;
		public override int OnGaveMeleeChance => 50;
		public override bool IsActiveOnGotMelee => true;
		public override int OnGotMeleeChance => 50;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
