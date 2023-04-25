using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Corpo de um Skald")]
    public class Skald : BaseCreature
    {
        [Constructable]
        public Skald() : base(AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4)
        {
            Name = "Skald";
            Body = 0x190;
            BaseSoundID = 0x482;

            SetStr(80);
            SetDex(80);
            SetInt(20);

            SetHits(100);
            SetMana(0);

            SetDamage(8, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 35);
            SetResistance(ResistanceType.Fire, 10, 20);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.MagicResist, 25.1, 30.0);
            SetSkill(SkillName.Tactics, 80.1, 90.0);
            SetSkill(SkillName.Anatomy, 80.1, 90.0);
            SetSkill(SkillName.Provocation, 80.1, 90.0);
            SetSkill(SkillName.Musicianship, 80.1, 90.0);

            Fame = 5000;
            Karma = 5000;

            VirtualArmor = 25;

            // Equipamento
            LeatherChest chest = new LeatherChest();
            chest.Hue = 2118;
            chest.Movable = true;
            AddItem(chest);

            LeatherLegs legs = new LeatherLegs();
            legs.Hue = 2118;
            legs.Movable = true;
            AddItem(legs);

            LeatherArms arms = new LeatherArms();
            arms.Hue = 2118;
            arms.Movable = true;
            AddItem(arms);

            LeatherGloves gloves = new LeatherGloves();
            gloves.Hue = 2118;
            gloves.Movable = true;
            AddItem(gloves);

            VikingSword weapon = new VikingSword();
            weapon.Movable = true;
            AddItem(weapon);
        }
        public override bool AlwaysMurderer => true;


        public override int GetAngerSound() { return 0x4FC; }
        public override int GetDeathSound() { return 0x4FE; }
        public override int GetHurtSound() { return 0x4FF; }
        public override int GetIdleSound() { return 0x482; }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (Utility.RandomDouble() < 0.05)
                c.DropItem(new SkaldInstrument());
        }

        public Skald(Serial serial) : base(serial) { }

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

    public class SkaldInstrument : BaseInstrument
    {
        public override void PlayInstrumentWell(Mobile from)
{
from.SendMessage("Você toca uma música inspiradora.");
Effects.PlaySound(from.Location, from.Map, 0x1ED);
}
    [Constructable]
    public SkaldInstrument() : base(0xEB3, 0x444, 0x48D)
    {
        Name = "Instrumento de Skald";
        Hue = 2118;
        Weight = 5.0;
    }

    public SkaldInstrument(Serial serial) : base(serial) { }

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