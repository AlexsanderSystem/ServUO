using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace CustomNpc

{
   [CorpseName("Corpo de um corvo")]
    public class Corvo : BaseCreature
    {
        [Constructable]
        public Corvo()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.6)
        {
            Name = "um corvo";
            Body = 5;
            Hue = 1109;
            BaseSoundID = 0x1DF;
            SetStr(12, 24);
            SetDex(26, 38);
            SetInt(10, 14);
            SetHits(6, 12);
            SetDamage(1, 3);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 10);
            SetResistance(ResistanceType.Cold, 5, 10);

            SetSkill(SkillName.MagicResist, 5.0);
            SetSkill(SkillName.Tactics, 5.0);
            SetSkill(SkillName.Wrestling, 5.0);
            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 10.1;
        }

        public override bool CanFly => true;

        public Corvo(Serial serial)
            : base(serial)
        {
        }

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

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.05)
            {
                c.DropItem(new RawChickenLeg());
            }
        }
    }
}
