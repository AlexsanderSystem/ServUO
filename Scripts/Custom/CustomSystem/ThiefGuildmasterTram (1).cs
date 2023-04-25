using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    public class ThiefGuildmasterTram : BaseGuildmaster
    {

        Point3D[] MoveLocations =
        {
            new Point3D( 1478, 1641, 20 ),//Britain [West]
            new Point3D( 1620, 1641, 35 ),//Britain [East]
            new Point3D( 2699, 2134, 0 ),//Buccs Den [North]
            new Point3D( 2713, 2206, 0 ),//Buccs Den [South]
            new Point3D( 2238, 1204, 0 ),//Cove
            new Point3D( 1404, 3798, 0 ),//Jhelom [Main Island]
            new Point3D( 1446, 4002, 0 ),//Jhelom [Small Island]
            new Point3D( 3798, 2262, 20 ),//Magincia
            new Point3D( 2480, 422, 15 ),//Minoc [North]
            new Point3D( 2496, 542, 0 ),//Minoc [South]
            new Point3D( 4406, 1111, 0 ),//Moonglow [West]
            new Point3D( 4484, 1116, 0 ),//Moonglow [East]
            new Point3D( 606, 2161, 0 ),//Skara Brae [North]
            new Point3D( 614, 2214, 0 ),//Skara Brae [South]
            new Point3D( 1902, 2832, 20 ),//Trinsic [South]
            new Point3D( 2016, 2846, 1 ),//Trinsic [East]
            new Point3D( 2901, 782, 0 ),//Vesper [North]
            new Point3D( 2901, 899, 0 ),//Vesper [South]
            new Point3D( 550, 990, 0 ), //Yew [Center]
            new Point3D( 622, 854, 0 ) //Yew [North]
        };

        private MoveTimer m_Timer;

        [Constructable]
        public ThiefGuildmasterTram()
            : base("thief")
        {
            this.SetSkill(SkillName.DetectHidden, 75.0, 98.0);
            this.SetSkill(SkillName.Hiding, 65.0, 88.0);
            this.SetSkill(SkillName.Lockpicking, 85.0, 100.0);
            this.SetSkill(SkillName.Snooping, 90.0, 100.0);
            this.SetSkill(SkillName.Poisoning, 60.0, 83.0);
            this.SetSkill(SkillName.Stealing, 90.0, 100.0);
            this.SetSkill(SkillName.Fencing, 75.0, 98.0);
            this.SetSkill(SkillName.Stealth, 85.0, 100.0);
            this.SetSkill(SkillName.RemoveTrap, 85.0, 100.0);

            m_Timer = new MoveTimer( this );
            ChangeLocation();
        }

        public void ChangeLocation()
        {
            this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Trammel );
            this.Hidden = true; //Arrives Hidden
        }

        public ThiefGuildmasterTram(Serial serial)
            : base(serial)
        {
        }

        public override NpcGuild NpcGuild
        {
            get
            {
                return NpcGuild.ThievesGuild;
            }
        }
        public override TimeSpan JoinAge
        {
            get
            {
                return TimeSpan.FromDays(7.0);
            }
        }
        public override void InitOutfit()
        {
            base.InitOutfit();

            if (Utility.RandomBool())
                this.AddItem(new Server.Items.Kryss());
            else
                this.AddItem(new Server.Items.Dagger());
        }

        public override bool CheckCustomReqs(PlayerMobile pm)
        {
            if (pm.Young)
            {
                this.SayTo(pm, 502089); // You cannot be a member of the Thieves' Guild while you are Young.
                return false;
            }
            else if (pm.Kills > 0)
            {
                this.SayTo(pm, 501050); // This guild is for cunning thieves, not oafish cutthroats.
                return false;
            }
            else if (pm.Skills[SkillName.Stealing].Base < 60.0)
            {
                this.SayTo(pm, 501051); // You must be at least a journeyman pickpocket to join this elite organization.
                return false;
            }

            return true;
        }

        public override void SayWelcomeTo(Mobile m)
        {
            this.SayTo(m, 1008053); // Welcome to the guild! Stay to the shadows, friend.
        }

        public override bool HandlesOnSpeech(Mobile from)
        {
            if (from.InRange(this.Location, 2))
                return true;

            return base.HandlesOnSpeech(from);
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;

            if (!e.Handled && from is PlayerMobile && from.InRange(this.Location, 2) && e.HasKeyword(0x1F)) // *disguise*
            {
                PlayerMobile pm = (PlayerMobile)from;

                if (pm.NpcGuild == NpcGuild.ThievesGuild)
                    this.SayTo(from, 501839); // That particular item costs 700 gold pieces.
                else
                    this.SayTo(from, 501838); // I don't know what you're talking about.

                e.Handled = true;
            }

            base.OnSpeech(e);
        }

        public override bool OnGoldGiven(Mobile from, Gold dropped)
        {
            if (from is PlayerMobile && dropped.Amount == 700)
            {
                PlayerMobile pm = (PlayerMobile)from;

                if (pm.NpcGuild == NpcGuild.ThievesGuild)
                {
                    from.AddToBackpack(new DisguiseKit());

                    dropped.Delete();
                    return true;
                }
            }

            return base.OnGoldGiven(from, dropped);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_Timer = new MoveTimer(this);
        }

        private class MoveTimer : Timer
        {
            private ThiefGuildmasterTram m_Owner;

            public MoveTimer(ThiefGuildmasterTram owner)
                : base(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5))
            {
                m_Owner = owner;
                TimerThread.PriorityChange(this, 7);
            }

            protected override void OnTick()
            {
                if (m_Owner == null)
                {
                    Stop();
                    return;
                }
                else if (m_Owner.Hits == m_Owner.HitsMax) // IE not in combat at all
                {
                    m_Owner.ChangeLocation();
                }
            }
        }
    }
}