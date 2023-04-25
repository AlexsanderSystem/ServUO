namespace Server.Items
{
    [Flipable(0x1441, 0x1440)]
    public class Cutlass : BaseSword
    {
        [Constructable]
        public Cutlass()
            : base(0x1441)
        {
            Weight = 8.0;
        }

        public Cutlass(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ShadowStrike;
        public override int StrengthReq => 60;
        public override int MinDamage => 13;
        public override int MaxDamage => 19;
        public override float Speed => 1.50f;

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