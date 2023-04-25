using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace ArcticHarpie

{
    [CorpseName("Corpo de Harpia do Ártico")]
    public class ArcticHarpie : BaseCreature
    {
        [Constructable]
        public ArcticHarpie() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Harpia do Ártico";
            Body = 73;
            BaseSoundID = 402;
            Hue = 1154;

            SetStr(126, 155);
            SetDex(81, 105);
            SetInt(36, 60);

            SetHits(76, 93);
            SetMana(60);

            SetDamage(5, 9);

            SetSkill(SkillName.Wrestling, 50.1, 60);
            SetSkill(SkillName.Tactics, 80.1, 90);
            SetSkill(SkillName.MagicResist, 50.1, 60);
            SetSkill(SkillName.Magery, 65.1, 75);

            Fame = 3500;
            Karma = -3500;



        }
        public override bool AlwaysMurderer => true;


        public override int Meat => 1;
        public override int Feathers => 50;
        public override bool CanFly => true;

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.3)
            {
                c.DropItem(new ArcticFeather());
            }
        }

        public override bool CanRummageCorpses { get { return true; } }

        public ArcticHarpie(Serial serial) : base(serial) { }

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

    public class ArcticFeather : Item
    {
        [Constructable]
        public ArcticFeather() : base(0x1BD1)
        {
            Hue = 1153;
            Weight = 1.0;
            Name = "Pena do Ártico";
        }
        public ArcticFeather(Serial serial) : base(serial) { }
        

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
