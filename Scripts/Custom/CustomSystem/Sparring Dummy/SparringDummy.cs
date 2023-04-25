using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable( 0x1070, 0x1074 )]
	public class SparringDummyEast : DamageableItem
	{
		[Constructable]
		public SparringDummyEast( )
			: base( 4212, 4212, 7604 )
		{
			Name = "Sparring Dummy";

			Level = ItemLevel.Hard;
		}

		public SparringDummyEast( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );
		}
	}
	
	[Flipable( 0x1070, 0x1074 )]
	public class SparringDummySouth : DamageableItem
	{
		[Constructable]
		public SparringDummySouth( )
			: base( 4208, 4208, 7604 )
		{
			Name = "Sparring Dummy";

			Level = ItemLevel.Hard;
		}

		public SparringDummySouth( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); //version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );
		}
	}
}