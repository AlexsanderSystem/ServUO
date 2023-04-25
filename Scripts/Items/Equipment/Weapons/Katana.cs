using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishKatana))]
    [Flipable(0x13FF, 0x13FE)]
    public class Katana : BaseSword
    {
        [Constructable]
        public Katana()
            : base(0x13FF)
        {
            Weight = 4.0;
        }

        public Katana(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
        public override int StrengthReq => 60;
        public override int MinDamage => 17;
        public override int MaxDamage => 21;
        public override float Speed => 2.10f;

        public override int DefHitSound => 0x23B;
        public override int DefMissSound => 0x23A;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 70;
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