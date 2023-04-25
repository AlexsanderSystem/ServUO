// Created By Erad of AOW

using System;
using Server;

namespace Server.Items
{
    public class Darkmagiciangloves : DragonGloves
    {
        public override int InitMaxHits{ get{ return 10; } }

        [Constructable]
        public Darkmagiciangloves()
        {
            Name = "Darkmagiciangloves";
            Hue = 2183;
            StrRequirement = 100;
            DexRequirement = 10;
            IntRequirement = 25;
            Attributes.BonusStr = 90;
            Attributes.BonusMana = 40;
            Attributes.RegenHits = 20;
            Attributes.AttackChance = 10;
            Attributes.WeaponDamage = 10;
            Attributes.Luck = 100;
            ArmorAttributes.MageArmor = 1;
            Attributes.CastSpeed = 10;
            Attributes.CastRecovery = 30;
            Attributes.LowerManaCost = 10;
            Attributes.LowerRegCost = 10;
            SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 );
        }

        public Darkmagiciangloves(Serial serial) : base( serial )
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
