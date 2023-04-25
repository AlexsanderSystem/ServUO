namespace Server.Items
{
    public class Neve : Item
    {
        private static readonly int[] m_Sounds = new int[]
        {
            0x1C9, 0x1CA, 0x1CB, 0x1CC, 0x1CD
        };
        [Constructable]
        public Neve()
            : base(0x20E8)
        {
            Hue = Utility.RandomList(0x899, 0x8A2, 0x8B0);
            Name = "Neve";
            Weight = 1.0;
        }

        public Neve(Serial serial)
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