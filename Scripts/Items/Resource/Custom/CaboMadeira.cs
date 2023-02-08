using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class CaboMadeira : Item
    {
        [Constructable]
        public CaboMadeira()
            : this(1)
        {
        }

        [Constructable]
        public CaboMadeira(int amount)
            : base(0xF8A)
        {
            Stackable = true;
            Amount = amount;
            Weight = 3.0;
            Name = "Cabo de madeira";
			Hue = 0xFF;
        }

        public CaboMadeira(Serial serial)
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

            int version = reader.ReadInt(); //peasant
        }
    }
}