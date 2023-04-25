namespace Server.Items
{
    public class SnowPileDeco : Item
    {
        public override double DefaultWeight => 50.0;

        private static readonly int[] m_Types = new int[] { 0x8E2, 0x8E0, 0x8E6, 0x8E5, 0x8E3 };

        [Constructable]
        public SnowPileDeco()
            : this(m_Types[Utility.Random(m_Types.Length)])
        {
        }

        [Constructable]
        public SnowPileDeco(int itemid)
            : base(itemid)
        {
            Hue = 0x481;
            Movable = false;
        }

        public SnowPileDeco(Serial serial)
            : base(serial)
        {
        }

        public override string DefaultName => "Pilha de Neve";

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}