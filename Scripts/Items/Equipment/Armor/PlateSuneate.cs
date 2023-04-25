namespace Server.Items
{
    public class PlateSuneate : BaseArmor
    {
        [Constructable]
        public PlateSuneate()
            : base(0x2788)
        {
            Weight = 17.0;
        }

        public PlateSuneate(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 10;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 2;
        public override int InitMinHits => 55;
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
