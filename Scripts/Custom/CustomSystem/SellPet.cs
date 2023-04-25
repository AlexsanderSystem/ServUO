using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Scripts.Commands 
{ 
	public class SellPet 
        { 
        	public static void Initialize() 
             	{ 
              		CommandSystem.Register( "sellpet", AccessLevel.Player, new CommandEventHandler( SellPet_OnCommand ) );
              		CommandSystem.Register( "sell pet", AccessLevel.Player, new CommandEventHandler( SellPet_OnCommand ) );
             	}

		[Usage( "SellPet" )]
		[Description( "Automatically releases a targeted pet and gives the player money as compensation." )]
		public static void SellPet_OnCommand( CommandEventArgs e )
		{
               		Mobile from = e.Mobile;

			from.SendMessage( "Target a pet to release it and receive money as compensation." );
			from.Target = new SellPetInternalTarget();
		}

		private class SellPetInternalTarget : Target
		{
			public SellPetInternalTarget() : base( 8, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = from as PlayerMobile;

					from.SendMessage( "This ability cannot be used on player mobiles." );
					return;
				}

				if ( targeted is Item )
				{
					from.SendMessage( "This ability cannot be used on items." );
					return;
				}

				if ( targeted is BaseCreature )
				{
					BaseCreature c = (BaseCreature)targeted;
                            		Container pack = from.Backpack;

                            		int goldamount = 0;
                            		goldamount = ( c.Str + c.Dex + c.Int ) / 2;

                    			if ( c.Controlled && c.ControlMaster == from )
					{
						c.Delete();
                                		from.SendMessage( String.Format( "You send your pet off on its own accord and {0}gp has been added to your backpack.", goldamount ) );

               					Gold gold = new Gold( goldamount );

						from.AddToBackpack( gold );
						from.PlaySound( 741 );
					}
					else
					{
						from.SendMessage( "This ability can only be used on creatures that belong to you." );
					}
				}
                                else
				{
					from.SendMessage( "This ability can only be used on creatures that belong to you." );
				}
			}
		}
	}
}