using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class Tacha : Item
    {
        [Constructable]
        public Tacha()
            : this(1)
        {
        }

        [Constructable]
        public Tacha(int amount)
            : base(0x3198)
        {
            Stackable = true;
            Amount = amount;
            Weight = 0.7;
            Name = "Tacha de Armadura";
        }

        public Tacha(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}