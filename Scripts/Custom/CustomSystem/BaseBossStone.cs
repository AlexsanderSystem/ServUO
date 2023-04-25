using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public class BaseBossStone : Item
    {
        private bool m_Active = false;
        private string m_Bossname = "No name";

        [CommandProperty(AccessLevel.GameMaster)]
        public string BossName
        {
            get { return m_Bossname; }
            set { m_Bossname = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Active
        {
            get { return m_Active; }
            set { m_Active = value; InvalidateProperties(); }
        }

        public BaseBossStone() : base(0x1179)
        {
            Name = "Boss Keeper";
            Movable = false;
        }

        public BaseBossStone(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write(m_Active);
            writer.Write(m_Bossname);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Active = reader.ReadBool();
            m_Bossname = reader.ReadString();
        }



        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel == AccessLevel.Player)
            {
                return;
            }

            if (Active)
            {
                this.PublicOverheadMessage(MessageType.Regular, 0, false, "This is already activated.");
            }
            else
            {
                this.PublicOverheadMessage(MessageType.Regular, 0, false, "Beginning activation of Boss...");
                this.Active = true;
                this.ActivateStone();
            }
        }

        public virtual void ActivateStone()
        {
            base.PublicOverheadMessage(MessageType.Regular, 0, false, "...finished!");
        }

        public virtual void AnnounceBoss(string announce)
        {
            ArrayList mobs = new ArrayList(World.Mobiles.Values);
            foreach (Mobile m in mobs)
            {
                if (m is TownCrier)
                {
                    m.Say(announce);
                }
            }
        }
    }
}
