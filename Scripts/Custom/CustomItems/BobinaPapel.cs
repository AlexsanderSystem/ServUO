using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class BobinaPapel : Item
    {
        [Constructable]
        public BobinaPapel()
            : this(1)
        {
        }

        [Constructable]
        public BobinaPapel(int amount)
            : base(0x0F98)
        {
            Stackable = true;
            Amount = amount;
            Weight = 10.0;
            Name = "Bobina de Papel";
			Hue = 0x90B;
        }

        public BobinaPapel(Serial serial)
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