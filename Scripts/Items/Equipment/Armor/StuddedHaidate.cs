namespace Server.Items
{
    public class StuddedHaidate : BaseArmor
    {
        [Constructable]
        public StuddedHaidate()
            : base(0x278B)
        {
            Weight = 15.0;
        }

        public StuddedHaidate(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 7;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 4;
        public override int InitMinHits => 35;
        public override int InitMaxHits => 45;
        public override int StrReq => 65;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
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
