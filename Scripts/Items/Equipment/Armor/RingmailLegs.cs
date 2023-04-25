namespace Server.Items
{
    [Flipable(0x13f0, 0x13f1)]
    public class RingmailLegs : BaseArmor
    {
        [Constructable]
        public RingmailLegs()
            : base(0x13F0)
        {
            Weight = 20.0;
        }

        public RingmailLegs(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 7;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 40;
        public override int InitMaxHits => 50;
        public override int StrReq => 55;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;
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
