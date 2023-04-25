using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;


namespace CustomNpc
{
    [CorpseName("Corpo de um Cervo")]
    public class Cervo : BaseCreature
    {
        [Constructable]
        public Cervo() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Cervo";
            Body = 237;
            BaseSoundID = 0x4F;

            SetStr(50, 70);
            SetDex(50, 70);
            SetInt(25, 45);

            SetHits(50, 120);
            SetMana(0);

            SetDamage(5, 10);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 10, 20);
            SetResistance(ResistanceType.Cold, 5, 10);

            SetSkill(SkillName.MagicResist, 10.1, 20.0);
            SetSkill(SkillName.Tactics, 20.1, 30.0);
            SetSkill(SkillName.Wrestling, 20.1, 30.0);

            Fame = 300;
            Karma = 0;

            VirtualArmor = 15;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 19.1;
        }

        public Cervo(Serial serial) : base(serial) {}

        //public override int Meat { get { return 2; } }
        //public override int Hides { get { return 2; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}