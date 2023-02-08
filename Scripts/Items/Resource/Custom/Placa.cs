using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class Placa : Item
    {
        [Constructable]
        public Placa()
            : this(1)
        {
        }

        [Constructable]
        public Placa(int amount)
            : base(0x1767)
        {
            Stackable = true;
            Amount = amount;
            Weight = 8.1;
            Name = "Placa de Armadura";
			Hue = 0xF8A;
        }

        public Placa(Serial serial)
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