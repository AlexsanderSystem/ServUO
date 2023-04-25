using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefTailoring), typeof(GargishLeatherChest))]
    [Flipable(0x2FC5, 0x317B)]
    public class LeafChest : BaseArmor
    {
        private bool _ElvesOnly;
        
        [CommandProperty(AccessLevel.GameMaster)]
        public bool ElfOnly { get { return _ElvesOnly; } set { _ElvesOnly = value; } }
        
        [Constructable]
        public LeafChest()
            : base(0x2FC5)
        {
            Weight = 12.0;
        }

        public LeafChest(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 6;
        public override int BaseColdResistance => 6;
        public override int BasePoisonResistance => 6;
        public override int BaseEnergyResistance => 6;
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
