using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class FlechaEnvenenada : Item
    {
        [Constructable]
        public FlechaEnvenenada()
            : this(1)
        {
        }

        [Constructable]
        public FlechaEnvenenada(int amount)
            : base(0x1053)
        {
            Stackable = true;
            Amount = amount;
            Weight = 2.0;
            Name = "Flecha Envenenada";
        }

        public FlechaEnvenenada(Serial serial)
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