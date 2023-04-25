using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public abstract class BaseFarm : BaseCreature
    {
		Dictionary<Mobile, int> m_DamageEntries;
		
        public BaseFarm(AIType aiType)
            : this(aiType, FightMode.Weakest)
        {
        }

        public BaseFarm(AIType aiType, FightMode mode)
            : base(aiType, mode, 18, 1, 0.1, 0.2)
        {
        }

        public BaseFarm(Serial serial)
            : base(serial)
        {
        }
		
        
		public virtual bool NoGoodies => false;
		public Type[] FarmArti => new Type[] { typeof(FarmTicket) };
        public override bool AlwaysMurderer => true;
        public override Poison PoisonImmune => Poison.Parasitic;
        public override Poison HitPoison => Poison.Lethal;
		public override bool ReacquireOnMovement => true;
        public override bool AutoDispel => true;
		public override bool BleedImmune => true;
		public override bool TeleportsTo => true;
		public override bool TaintedLifeAura => true;
		public override bool DeleteCorpseOnDeath => true;
        public override double AutoDispelChance => 75.0;
        public override bool BardImmune => true;
        public override bool Unprovokable => true;
        public override bool Uncalmable => true;

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
		
		        public virtual void RegisterDamageTo(Mobile m)
        {
            if (m == null)
                return;

            foreach (DamageEntry de in m.DamageEntries)
            {
                Mobile damager = de.Damager;

                Mobile master = damager.GetDamageMaster(m);

                if (master != null)
                    damager = master;

                RegisterDamage(damager, de.DamageGiven);
            }
        }

        public void RegisterDamage(Mobile from, int amount)
        {
            if (from == null || !from.Player)
                return;

            if (m_DamageEntries.ContainsKey(from))
                m_DamageEntries[from] += amount;
            else
                m_DamageEntries.Add(from, amount);
        }
		
        public void AwardArtifact(Item artifact)
        {
            if (artifact == null)
                return;

            int totalDamage = 0;

            Dictionary<Mobile, int> validEntries = new Dictionary<Mobile, int>();

            foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
            {
                if (IsEligible(kvp.Key, artifact))
                {
                    validEntries.Add(kvp.Key, kvp.Value);
                    totalDamage += kvp.Value;
                }
            }

            int randomDamage = Utility.RandomMinMax(1, totalDamage);

            totalDamage = 0;

            foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
            {
                totalDamage += kvp.Value;

                if (totalDamage > randomDamage)
                {
                    GiveArtifact(kvp.Key, artifact);
                    break;
                }
            }
        }

        public void GiveArtifact(Mobile to, Item artifact)
        {
            if (to == null || artifact == null)
                return;

            to.PlaySound(0x5B4);

            Container pack = to.Backpack;

            if (pack == null || !pack.TryDropItem(to, artifact, false))
                artifact.Delete();
            else
                to.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
        }

        public bool IsEligible(Mobile m, Item Artifact)
        {
            return m.Player && m.Alive && m.InRange(Location, 32) && m.Backpack != null && m.Backpack.CheckHold(m, Artifact, false);
        }

        public Item GetArtifact()
        {
            double random = Utility.RandomDouble();

            if (0.1 >= random)
                return CreateArtifact(FarmArti);

            return null;
        }

        public Item CreateArtifact(Type[] list)
        {
            if (list.Length == 0)
                return null;

            int random = Utility.Random(list.Length);

            Type type = list[random];

            Item artifact = Loot.Construct(type);

            return artifact;
        }
		
        public override bool OnBeforeDeath()
        {
            if (!NoKillAwards)
            {
                if (NoGoodies)
                    return base.OnBeforeDeath();

                m_DamageEntries = new Dictionary<Mobile, int>();

                RegisterDamageTo(this);
                AwardArtifact(GetArtifact());
            }

            return base.OnBeforeDeath();
		}
    }
}
//Created by DragnMaw on 12/27/2020
//Edited by DragnMaw on 12/28/2020
//Edited by DragnMaw on 12/29/2020
//Edited by DragnMaw on 1/1/2021