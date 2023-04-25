using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishLance))]
    [Flipable(0x26C0, 0x26CA)]
    public class Lance : BaseSword
    {
        [Constructable]
        public Lance()
            : base(0x26C0)
        {
            Weight = 12.0;
        }

        public Lance(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
        public override int StrengthReq => 90;
        public override int MinDamage => 18;
        public override int MaxDamage => 24;
        public override float Speed => 0.25f;

        public override int DefHitSound => 0x23C;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 70;
        public override SkillName DefSkill => SkillName.Fencing;
        public override WeaponType DefType => WeaponType.Piercing;
        public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;
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