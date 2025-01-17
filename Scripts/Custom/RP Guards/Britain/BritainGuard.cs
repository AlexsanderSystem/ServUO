using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class BritainGuard : BaseRanger
	{ 

		[Constructable] 
		public BritainGuard() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "the Knight"; 

			SetStr( 1750, 1750 );
			SetDex( 150, 150 );
			SetInt( 61, 75 );

			SetSkill( SkillName.MagicResist, 120.0, 120.0 );
			SetSkill( SkillName.Swords, 120.0, 120.0 );
			SetSkill( SkillName.Tactics,120.0, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0,120.0 );

			AddItem( new VikingSword() );
			AddItem( new HeaterShield() );
			AddItem( new PlateLegs());
			AddItem( new PlateArms());
			AddItem( new PlateGorget());
			AddItem( new Boots() );
			AddItem( new PlateHelm() );
			AddItem( new Cloak(38) );
			AddItem( new PlateGloves() );
			AddItem( new BodySash(941) );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
				AddItem( new FemalePlateChest() );
				
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

				AddItem( new PlateChest());
				
			}

			Utility.AssignRandomHair( this );
		}

		public BritainGuard( Serial serial ) : base( serial ) 
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