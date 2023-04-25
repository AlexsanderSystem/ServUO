namespace Server.Items
{
    public class LeafGorget : BaseArmor
    {
        private bool _ElvesOnly;
        
        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public LeafGorget()
            : base(0x2FC7)
        {
            Weight = 12.0;
        }

        public LeafGorget(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 5;
        public override int BaseColdResistance => 5;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;
        public override int StrReq => 42;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
        }
    }
}
