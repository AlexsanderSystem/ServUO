using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class Seda : Item
    {
        [Constructable]
        public Seda()
            : this(1)
        {
        }

        [Constructable]
        public Seda(int amount)
            : base(0x423A)
        {
            Stackable = true;
            Amount = amount;
            Weight = 0.1;
            Name = "Seda";
        }

        public Seda(Serial serial)
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