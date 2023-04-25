namespace Server.Items
{
    public class StuddedMempo : BaseArmor
    {
        [Constructable]
        public StuddedMempo()
            : base(0x279D)
        {
            Weight = 12.0;
        }

        public StuddedMempo(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 7;
        public override int BaseFireResistance => 2;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 2;
        public override int BaseEnergyResistance => 3;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;
        public override int StrReq => 60;
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
