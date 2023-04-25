namespace Server.Items
{
    [Flipable]
    public class LeafGloves : BaseArmor
    {
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

        private bool _ElvesOnly;
        
        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public LeafGloves()
            : base(0x2FC6)
        {
            Weight = 12.0;
        }

        public LeafGloves(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();

            if (version < 1)
            {
                if (reader.ReadBool())
                {
                    reader.ReadInt();
                    reader.ReadInt();
                }
            }
        }
    }
}
