using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class Fisherman : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Fisherman()
            : base("Pescador")
        {
            SetSkill(SkillName.Fishing, 75.0, 98.0);
        }

        public Fisherman(Serial serial)
            : base(serial)
        {
        }

        public override NpcGuild NpcGuild => NpcGuild.FishermensGuild;
        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBFisherman());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            SetWearable(new FishingPole(), dropChance: 1);
        }

        public override bool HandlesOnSpeech(Mobile from)
{
    return true;
}

public override void OnSpeech(SpeechEventArgs e)
{
    if (e.Speech.ToLower() == "oi")
    {
        Say("Olá! Estou pescando agora. Se você precisar de equipamento de pesca, fale com o Lenhador.", e.Mobile);
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