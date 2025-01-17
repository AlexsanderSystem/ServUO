using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class Farmer : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Farmer()
            : base("Cozinheiro")
        {
            SetSkill(SkillName.Lumberjacking, 36.0, 68.0);
            SetSkill(SkillName.TasteID, 36.0, 68.0);
            SetSkill(SkillName.Cooking, 36.0, 68.0);
        }

        public Farmer(Serial serial)
            : base(serial)
        {
        }

        public override VendorShoeType ShoeType => VendorShoeType.ThighBoots;
        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBFarmer());
        }

        public override int GetShoeHue()
        {
            return 0;
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            SetWearable(new WideBrimHat(), Utility.RandomNeutralHue(), 1);
        }

                        public override bool HandlesOnSpeech(Mobile from)
{
    return true;
}

public override void OnSpeech(SpeechEventArgs e)
{
    if (e.Speech.ToLower() == "oi")
    {
        Say("Olá! Estou trabalhando agora. Se precisa vender algo avise.", e.Mobile);
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