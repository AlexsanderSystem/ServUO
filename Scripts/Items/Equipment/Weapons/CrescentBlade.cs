using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishTalwar))]
    [Flipable(0x26C1, 0x26CB)]
    public class CrescentBlade : BaseSword
    {
        [Constructable]
        public CrescentBlade()
            : base(0x26C1)
        {
            Weight = 6.0;
        }

        public CrescentBlade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 55;
        public override int MinDamage => 13;
        public override int MaxDamage => 17;
        public override float Speed => 1.50f;

        public override int DefHitSound => 0x23B;
        public override int DefMissSound => 0x23A;
        public override int InitMinHits => 51;
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
