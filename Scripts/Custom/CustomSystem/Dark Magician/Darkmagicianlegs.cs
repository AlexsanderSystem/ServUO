// Created By Erad of AOW

using System;
using Server;

namespace Server.Items
{
    public class Darkmagicianlegs : DragonLegs
    {
        public override int InitMinHits{ get{ return 10; } }

        [Constructable]
        public Darkmagicianlegs()
        {
            Name = "Darkmagicianlegs";
            Hue = 2183;
            Attributes.BonusStr = 15;
            Attributes.BonusHits = 20;
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 10;
            Attributes.Luck = 50;
            Attributes.SpellDamage = 40;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 20;
            ArmorAttributes.LowerStatReq = 100;
            Attributes.CastSpeed = 20;
            Attributes.CastRecovery = 10;
            Attributes.LowerManaCost = 10;
            Attributes.LowerRegCost = 10;
            SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 );
        }

        public Darkmagicianlegs(Serial serial) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace
