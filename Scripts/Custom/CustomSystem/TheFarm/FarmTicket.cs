using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Collections.Generic;
using Server.Regions;
using Server.Accounting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Multis;
using Server.Targeting;

namespace Server.Items
{
    public class FarmTicket : Item
    {
		[Constructable]
        public FarmTicket()
            : base(0x14F0)
        {
            Name = "Farm Ticket";
			LootType = LootType.Cursed;
			Weight = 0.1;
		}
		
		public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            list.Add( "Reward Item" );
			list.Add( "Double Click: Randomly recieve your rewards" );
        }
		
        public FarmTicket(Serial serial)
            : base(serial)
        {
        }
	
        public override void OnDoubleClick(Mobile from)
		{      		
			if (!from.InRange(GetWorldLocation(), 2))
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
            else if (!from.Region.IsPartOf<HouseRegion>())
                from.SendLocalizedMessage(502092); // You must be in your house to do this.
			else
				{
				Timer.DelayCall( TimeSpan.FromSeconds( 0.0 ), new TimerStateCallback( OpenTicket ), from );
				from.SendMessage("You cash in the ticket!");
				from.Direction = from.GetDirectionTo(this);
				from.Animate(32, 5, 1, true, true, 0);
				this.Delete();
				}
		}

		public static void OpenTicket( object state )
			{
				
				Mobile m = (Mobile)state;
				PlayerMobile pm = m as PlayerMobile;

				pm.BankBox.DropItem(new Gold(1000));
										
				switch(Utility.Random(6))
				{
					case 0: pm.AddToBackpack(new ValoriteIngot(50)); break;
					case 1: pm.AddToBackpack(new BarbedLeather(50)); break;
					case 2: pm.AddToBackpack(new HeartwoodBoard(50)); break;
					case 3: break;
					case 4: break;
					case 5: break;
				}
					
				switch(Utility.Random(100))
				{
					case 99: pm.AddToBackpack(new ClothingBlessDeed()); World.Broadcast(8, true, "{0} has just recieved a Clothing Bless Deed!", pm); break;
				}
					
				switch(Utility.Random(100))
				{
					case 99: pm.AddToBackpack(new PowderOfTemperament(10)); World.Broadcast(8, true, "{0} has just recieved a Powder of Fortification!", pm); break;
				}
				
				switch(Utility.Random(2))
				{
					case 0: break;
					case 1: pm.DepositSovereigns(5); pm.SendMessage("5 Sovereigns have been added to your virtual wallet."); break;
				}
				
				switch(Utility.Random(100))
				{
					case 99: pm.BankBox.DropItem(new Gold(1000000));
					pm.LocalOverheadMessage(MessageType.Regular, 0xFE, false, "*1 Million Coins added to your bank*");
					World.Broadcast(8, true, "{0} has just hit the 1 million prize!", pm);
					break;
				}
					
				switch(Utility.Random(100))
				{
					case 99: pm.DepositSovereigns(1000); 
					pm.LocalOverheadMessage(MessageType.Regular, 0xFE, false, "1000 Sovereigns have been added to your virtual wallet.");
					World.Broadcast(8, true, "{0} has just hit the 1000 Sovereign prize!", pm);
					break;
				}
			}

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
//Created on 12/27/2020 by DragnMaw
//Edited on 12/28/2020 by DragnMaw
//Edited on 1/1/2021 by DragnMaw
//Edited on 1/2/2021 by DragnMaw