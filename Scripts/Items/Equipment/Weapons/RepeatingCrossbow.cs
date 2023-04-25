using System;

namespace Server.Items
{
    [Flipable(0x26C3, 0x26CD)]
    public class RepeatingCrossbow : BaseRanged
    {
        [Constructable]
        public RepeatingCrossbow()
            : base(0x26C3)
        {
            Weight = 12.0;
        }

        public RepeatingCrossbow(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0x1BFE;
        public override Type AmmoType => typeof(Bolt);
        public override Item Ammo => new Bolt();
        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MovingShot;
        public override int StrengthReq => 70;
        public override int MinDamage => 13;
        public override int MaxDamage => 20;
        public override float Speed => 1.60f;

        public override int DefMaxRange => 7;
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
