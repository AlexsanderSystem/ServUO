namespace Server.Items
{
    [Flipable(0x27A6, 0x27F1)]
    public class Tetsubo : BaseBashing
    {
        [Constructable]
        public Tetsubo()
            : base(0x27A6)
        {
            Weight = 15.0;
            Layer = Layer.TwoHanded;
        }

        public Tetsubo(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.FrenziedWhirlwind;
        public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;
        public override int StrengthReq => 80;
        public override int MinDamage => 24;
        public override int MaxDamage => 40;
        public override float Speed => 2.50f;

        public override int DefHitSound => 0x233;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 60;
        public override int InitMaxHits => 65;
        public override WeaponAnimation DefAnimation => WeaponAnimation.Bash2H;
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