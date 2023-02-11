namespace Server.Items
{
    public class HeavyPlateJingasa : BaseArmor
    {
        [Constructable]
        public HeavyPlateJingasa()
            : base(0x2777)
        {
            Weight = 5.0;
        }

        public HeavyPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 11;
        public override int BaseFireResistance => 1;
        public override int BaseColdResistance => 1;
        public override int BasePoisonResistance => 1;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 50;
        public override int InitMaxHits => 70;
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
