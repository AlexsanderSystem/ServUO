using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class PontaFerro : Item
    {
        [Constructable]
        public PontaFerro()
            : this(1)
        {
        }

        [Constructable]
        public PontaFerro(int amount)
            : base(0x1053)
        {
            Stackable = true;
            Amount = amount;
            Weight = 0.1;
            Name = "Ponta de ferro para flecha";
        }

        public PontaFerro(Serial serial)
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


