namespace Server.Items
{
    [Flipable(0x13B8, 0x13B7)]
    public class ThinLongsword : BaseSword
    {
        [Constructable]
        public ThinLongsword()
            : base(0x13B8)
        {
            Weight = 4.0;
        }

        public ThinLongsword(Serial serial)
            : base(serial)
        {
        }

        public override int StrengthReq => 50;
        public override int MinDamage => 16;
        public override int MaxDamage => 21;
        public override float Speed => 2.00f;

        public override int DefHitSound => 0x237;
        public override int DefMissSound => 0x23A;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 110;
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