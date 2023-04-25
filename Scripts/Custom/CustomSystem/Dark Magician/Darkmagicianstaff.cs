// Created By Erad of AOW

using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Darkmagicianstaff : GnarledStaff
  {
public override int ArtifactRarity{ get{ return 44; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 155; } }

      [Constructable]
		public Darkmagicianstaff()
		{
			Weight = 7;
          Name = "Darkmagicianstaff";
          Hue = 2183;
      WeaponAttributes.HitColdArea = 40;
      WeaponAttributes.HitDispel = 75;
      WeaponAttributes.HitEnergyArea = 50;
      WeaponAttributes.HitFireArea = 10;
      WeaponAttributes.HitFireball = 75;
      WeaponAttributes.HitHarm = 75;
      WeaponAttributes.HitLeechHits = 75;
      WeaponAttributes.HitLightning = 75;
      WeaponAttributes.HitMagicArrow = 75;
      WeaponAttributes.ResistColdBonus = 53;
      WeaponAttributes.ResistEnergyBonus = 100;
      WeaponAttributes.ResistPhysicalBonus = 27;
      WeaponAttributes.ResistPoisonBonus = 30;
      WeaponAttributes.ResistFireBonus = 30;
      WeaponAttributes.UseBestSkill = 1;
      Attributes.AttackChance = 30;
      Attributes.DefendChance = 50;
      Attributes.EnhancePotions = 44;
      Attributes.LowerManaCost = 19;
      Attributes.LowerRegCost = 25;
      Attributes.RegenMana = 5;
      Attributes.SpellChanneling = 1;

		}

		public Darkmagicianstaff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
