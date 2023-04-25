using System;
using System.Collections.Generic;
using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class DungeonBosses : BaseBossStone
    {
        public int i { get; private set; }

        [Constructable]
        public DungeonBosses()
        {
            Hue = 150;
            BossName = "Dungeon Bosses";
        }

        public DungeonBosses(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        private static int GetRandomMaxSpawn(int i)
        {
            if (i == 0)
                return Utility.RandomMinMax(1, 2);
            return Utility.RandomMinMax(1, 4);
        }

        private static int GetRandomTickSpawn(int i)
        {
            if (i == 0)
                return 1;
            return Utility.RandomMinMax(1, 2);
        }

        private static TimeSpan GetRespawnMaxTimer(int i)
        {
            if (i == 0)
                return new TimeSpan(0, 0, 0);
            return new TimeSpan(0, 0, 1);
        }

        public override void ActivateStone()
        {

            #region Boss Spawn

            if (i == 0)
            {
                var Boss = new XmlSpawner();
                Boss.Map = Map.Ilshenar;
                Boss.Name = "DungeonBosses";
                Boss.MoveToWorld(new Point3D(2114, 1006, -28));
                Boss.MaxCount = 30;
                Boss.HomeRange = 10;
                Boss.SpawnRange = 10;
                Boss.Group = true;
                Boss.SmartSpawning = true;

                // Wave 1
                Boss.AddSpawn = typeof(HellCat).Name;
                if (Boss.SpawnObjects.Length > 0)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 1;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 15;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 15;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].RestrictKillsToSubgroup = true;
                }
                Boss.AddSpawn = typeof(PredatorHellCat).Name;
                if (Boss.SpawnObjects.Length > 1)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 1;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 15;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 15;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].RestrictKillsToSubgroup = true;
                }

                // Wave 2
                Boss.AddSpawn = typeof(BloodElemental).Name;
                if (Boss.SpawnObjects.Length > 2)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].RestrictKillsToSubgroup = true;
                }
                Boss.AddSpawn = typeof(Daemon).Name;
                if (Boss.SpawnObjects.Length > 3)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 10;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].RestrictKillsToSubgroup = true;
                }

                // Wave 3
                Boss.AddSpawn = typeof(Succubus).Name;
                if (Boss.SpawnObjects.Length > 4)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 5;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 5;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 5;
                }
                Boss.AddSpawn = typeof(Balron).Name;
                if (Boss.SpawnObjects.Length > 5)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 5;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 5;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 5;
                }

                // Boss Spawn

                Boss.AddSpawn = typeof(Barracoon).Name;
                if (Boss.SpawnObjects.Length > 6)
                {
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].Available = true;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SubGroup = Boss.SpawnObjects.Length;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].SpawnsPerTick = 1;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].KillsNeeded = 1;
                    Boss.SpawnObjects[Boss.SpawnObjects.Length - 1].MaxCount = 1;
                }

                Boss.KillReset = 0;
                for (int o = 0; o < Boss.SpawnObjects.Length; o++)
                {
                    Boss.KillReset += Boss.SpawnObjects[o].KillsNeeded;
                }
                Boss.MinDelay = new TimeSpan(0, 10, 0);
                Boss.MaxDelay = new TimeSpan(0, 10, 0);
                Boss.NextSpawn = new TimeSpan(0, 0, 0);
                Boss.SortSpawns();
                Boss.DoReset = false;
                Boss.SequentialSpawn = 1;
                Boss.Start();
            }

            #endregion

            base.ActivateStone();
        }
    }
}
