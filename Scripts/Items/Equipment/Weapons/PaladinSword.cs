namespace Server.Items
{
    [Flipable(0x26CE, 0x26CF)]
    public class PaladinSword : BaseSword
    {
        [Constructable]
        public PaladinSword()
            : base(0x26CE)
        {
            Weight = 8.0;
        }

        public PaladinSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;
        public override int StrengthReq => 85;
        public override int MinDamage => 28;
        public override int MaxDamage => 32;
        public override float Speed => 3.50f;
        public override int InitMinHits => 36;
        public override int InitMaxHits => 48;
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