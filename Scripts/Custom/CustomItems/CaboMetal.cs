using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class CaboMetal : Item
    {
        [Constructable]
        public CaboMetal()
            : this(1)
        {
        }

        [Constructable]
        public CaboMetal(int amount)
            : base(0xF8A)
        {
            Stackable = true;
            Amount = amount;
            Weight = 6.0;
            Name = "Cabo de metal";
        }

        public CaboMetal(Serial serial)
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