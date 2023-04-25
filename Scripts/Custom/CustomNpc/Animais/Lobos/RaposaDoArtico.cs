using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles

{
    [CorpseName("Uma raposa do Ártico morta")]
    public class RaposaArtico : BaseCreature
    {
        [Constructable]
        public RaposaArtico() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Raposa do Ártico";
            Body = 225;
            BaseSoundID = 0x57;

            SetStr(26, 50);
            SetDex(41, 65);
            SetInt(16, 30);

            SetHits(16, 30);
            SetMana(0);

            SetDamage(3, 7);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 10, 20);
            SetResistance(ResistanceType.Cold, 30, 50);
            SetResistance(ResistanceType.Poison, 5, 10);

            SetSkill(SkillName.MagicResist, 15.1, 30.0);
            SetSkill(SkillName.Tactics, 19.2, 34.0);
            SetSkill(SkillName.Wrestling, 19.2, 34.0);

            Fame = 300;
            Karma = 0;

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;
        }
        public override bool AlwaysMurderer => true;

        public RaposaArtico(Serial serial) : base(serial)
        {
        }

        public override int Meat { get { return 1; } }
        public override int Hides { get { return 12; } }

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
