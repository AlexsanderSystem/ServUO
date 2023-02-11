namespace Server.Items
{
    public class DecorativePlateKabuto : BaseArmor
    {
        [Constructable]
        public DecorativePlateKabuto()
            : base(0x2778)
        {
            Weight = 16.0;
        }

        public DecorativePlateKabuto(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 11;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 55;
        public override int InitMaxHits => 75;
        public override int StrReq => 70;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
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
