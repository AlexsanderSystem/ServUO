using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class BarbanteArco : Item
    {
        [Constructable]
        public BarbanteArco()
            : this(1)
        {
        }

        [Constructable]
        public BarbanteArco(int amount)
            : base(0x14F8)
        {
            Stackable = true;
            Amount = amount;
            Weight = 4.0;
            Name = "Barbante de arco";
			Hue = 0x973;
        }

        public BarbanteArco(Serial serial)
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