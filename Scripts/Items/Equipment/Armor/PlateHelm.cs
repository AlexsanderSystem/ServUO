namespace Server.Items
{
    public class PlateHelm : BaseArmor
    {
        [Constructable]
        public PlateHelm()
            : base(0x1412)
        {
            Weight = 10.0;
        }

        public PlateHelm(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 14;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 65;
        public override int StrReq => 80;
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
