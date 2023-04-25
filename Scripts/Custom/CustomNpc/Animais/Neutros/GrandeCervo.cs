using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace CustomNpc
{
    [CorpseName("Corpo de um Grande Cervo")]
     public class GrandeCervo : BaseCreature
    {
        [Constructable]
        public GrandeCervo() : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Grande Cervo";
            Body = 0xEA;
            BaseSoundID = 0x4F;

            SetStr(90, 130);
            SetDex(50, 70);
            SetInt(25, 45);

            SetHits(120, 200);
            SetMana(0);

            SetDamage(8, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 30);
            SetResistance(ResistanceType.Cold, 10, 60);

            SetSkill(SkillName.MagicResist, 20.1, 30.0);
            SetSkill(SkillName.Tactics, 30.1, 40.0);
            SetSkill(SkillName.Wrestling, 30.1, 60.0);

            Fame = 600;
            Karma = 0;

            VirtualArmor = 30;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 29.1;
    }

    public override int Meat { get { return 10; } }
    //public override int Leather { get { return 8; } }

    public GrandeCervo(Serial serial) : base(serial) { }

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