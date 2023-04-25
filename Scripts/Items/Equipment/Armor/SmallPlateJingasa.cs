namespace Server.Items
{
    public class SmallPlateJingasa : BaseArmor
    {
        [Constructable]
        public SmallPlateJingasa()
            : base(0x2784)
        {
            Weight = 15.0;
        }

        public SmallPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 10;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 55;
        public override int InitMaxHits => 60;
        public override int StrReq => 60;
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
