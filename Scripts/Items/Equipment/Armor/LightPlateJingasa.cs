namespace Server.Items
{
    public class LightPlateJingasa : BaseArmor
    {
        [Constructable]
        public LightPlateJingasa()
            : base(0x2781)
        {
            Weight = 15.0;
        }

        public LightPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 7;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        public override int InitMinHits => 55;
        public override int InitMaxHits => 60;
        public override int StrReq => 55;
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
