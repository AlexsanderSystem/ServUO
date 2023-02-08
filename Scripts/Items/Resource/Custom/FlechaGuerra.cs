using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class FlechaGuerra : Item
    {
        [Constructable]
        public FlechaGuerra()
            : this(1)
        {
        }

        [Constructable]
        public FlechaGuerra(int amount)
            : base(0x1053)
        {
            Stackable = true;
            Amount = amount;
            Weight = 4.0;
            Name = "Flecha de Guerra";
        }

        public FlechaGuerra(Serial serial)
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