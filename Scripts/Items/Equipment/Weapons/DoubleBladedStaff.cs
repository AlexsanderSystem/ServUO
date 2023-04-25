using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DualPointedSpear))]
    [Flipable(0x26BF, 0x26C9)]
    public class DoubleBladedStaff : BaseSpear
    {
        [Constructable]
        public DoubleBladedStaff()
            : base(0x26BF)
        {
            Weight = 8.0;
        }

        public DoubleBladedStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;
        public override int StrengthReq => 70;
        public override int MinDamage => 24;
        public override int MaxDamage => 28;
        public override float Speed => 2.25f;

        public override int InitMinHits => 31;
        public override int InitMaxHits => 80;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}