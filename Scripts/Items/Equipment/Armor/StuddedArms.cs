namespace Server.Items
{
    [Flipable(0x13dc, 0x13d4)]
    public class StuddedArms : BaseArmor
    {
        [Constructable]
        public StuddedArms()
            : base(0x13DC)
        {
            Weight = 8.0;
        }

        public StuddedArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 6;
        public override int BaseFireResistance => 3;
        public override int BaseColdResistance => 3;
        public override int BasePoisonResistance => 3;
        public override int BaseEnergyResistance => 4;
        public override int InitMinHits => 35;
        public override int InitMaxHits => 45;
        public override int StrReq => 45;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;
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
