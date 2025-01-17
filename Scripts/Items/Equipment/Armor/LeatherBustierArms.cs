using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefTailoring), typeof(FemaleGargishLeatherChest))]
    [Flipable(0x1c0a, 0x1c0b)]
    public class LeatherBustierArms : BaseArmor
    {
        [Constructable]
        public LeatherBustierArms()
            : base(0x1C0A)
        {
            Weight = 10.0;
        }

        public LeatherBustierArms(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 2;
        public override int BaseFireResistance => 5;
        public override int BaseColdResistance => 2;
        public override int BasePoisonResistance => 5;
        public override int BaseEnergyResistance => 5;
        public override int InitMinHits => 30;
        public override int InitMaxHits => 40;
        public override int StrReq => 50;
        public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
        public override CraftResource DefaultResource => CraftResource.RegularLeather;
        public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;
        public override bool AllowMaleWearer => false;
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
