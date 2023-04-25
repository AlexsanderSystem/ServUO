using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a FarmMob corpse")]
    public class FarmMob : BaseFarm
    {
        [Constructable]
        public FarmMob()
            : base(AIType.AI_Mage)
        {
            Name = "Farm Mob";
            switch(Utility.Random(10))
			{
				case 0: Body = 40; break;
				case 1: Body = 18; break;
				case 2: Body = 46; break;
				case 3: Body = 76; break;
				case 4: Body = 75; break;
				case 5: Body = 83; break;
				case 6: Body = 9; break;
				case 7: Body = 318; break;
				case 8: Body = 249; break;
				case 9: Body = 174; break;
			}
			
            BaseSoundID = 357;
			switch(Utility.Random(8))
			{
				case 0: Hue = 1117; break;
				case 1: Hue = 1178; break;
				case 2: Hue = 1179; break;
				case 3: Hue = 1187; break;
				case 4: Hue = 1188; break;
				case 5: Hue = 1190; break;
				case 6: Hue = 1196; break;
				case 7: Hue = 1947; break;
			}
            SetStr(1, 500);
            SetDex(1, 250);
            SetInt(1, 250);

            SetHits(1, 1000);

            SetDamage(1, 20);

			switch(Utility.Random(5))
			{
				case 0: SetDamageType(ResistanceType.Physical, 100); break;
				case 1: SetDamageType(ResistanceType.Fire, 100); break;
				case 2: SetDamageType(ResistanceType.Cold, 100); break;
				case 3: SetDamageType(ResistanceType.Poison, 100); break;
				case 4: SetDamageType(ResistanceType.Energy, 100); break;
			}
			
            SetResistance(ResistanceType.Physical, 1, 100);
            SetResistance(ResistanceType.Fire, 1, 100);
            SetResistance(ResistanceType.Cold, 1, 100);
            SetResistance(ResistanceType.Poison, 1, 100);
            SetResistance(ResistanceType.Energy, 1, 100);

            SetSkill(SkillName.Anatomy, 0.1, 120.0);
            SetSkill(SkillName.EvalInt, 0.1, 120.0);
            SetSkill(SkillName.Magery, 0.1, 120.0);
            SetSkill(SkillName.Meditation, 0.1, 120.0);
            SetSkill(SkillName.MagicResist, 0.1, 120.0);
            SetSkill(SkillName.Tactics, 0.1, 120.0);
            SetSkill(SkillName.Wrestling, 0.1, 120.0);

            Fame = 0;
            Karma = -0;
			
			SetWeaponAbility(WeaponAbility.Disarm);
        }

        public FarmMob(Serial serial)
            : base(serial)
        {
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
//Created on 12/28/2020 by DragnMaw
//Edited on 12/30/2020 by DragnMaw
//Edited on 1/1/2021 by DragnMaw