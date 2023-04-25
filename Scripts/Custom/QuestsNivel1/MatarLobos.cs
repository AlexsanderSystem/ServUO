using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class MatarOrcs : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        //public override QuestChain ChainID => QuestChain.Tutorial;

        //public override Type NextQuest =>  typeof(CloseEnoughQuest)

        public override object Title
        {
            get
            {
                return "Lobos Ferozes";
            }
        }
        public override object Description
        {
            get
            {
                return "A voz dos Deuses clama por bravos guerreiros! Lobos selvagens ameaçam nossa aldeia, e somente os mais corajosos podem protegê-la. Mate essas feras e prove seu valor. Em troca, receberá uma generosa recompensa, incluindo moedas de ouro e pão fresco, assado por mim, o renomado Brødsmiðrda vila.";
            }
        }
        public override object Refuse
        {
            get
            {
                return "Se você não está disposto a provar sua coragem contra lobos, como pode esperar entrar em Valhalla?";
            }
        }
        public override object Uncomplete
        {
            get
            {
                return "Vejo que retornou, mas ainda acho que tem mais lobos a serem mortos !";
            }
        }
        public override object Complete
        {
            get
            {
                return "Você é forte como um guerreiro viking, digno de Odin e do Valhalla";
            }
        }

        public MatarOrcs()
            : base()
        {
            this.AddObjective(new SlayObjective(typeof(DireWolf), "Lobos Cinzas", 10));
            this.AddReward(new BaseReward(typeof(Gold), 32, "Moedas de Ouro"));
            this.AddReward(new BaseReward(typeof(BreadLoaf), 4, "Unidades de pao"));
        }

        public override void OnCompleted()
        {
            this.Owner.PlaySound(this.CompleteSound);
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
    }

    public class FazendeiroDoido : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] {
                    typeof(MatarOrcs)
        };
            }
        }


        [Constructable]
        public FazendeiroDoido()
            : base("Thorvald,", "")
        {
            this.SetSkill(SkillName.Anatomy, 120.0, 120.0);
            this.SetSkill(SkillName.Parry, 120.0, 120.0);
            this.SetSkill(SkillName.Healing, 120.0, 120.0);
            this.SetSkill(SkillName.Tactics, 120.0, 120.0);
            this.SetSkill(SkillName.Swords, 120.0, 120.0);
            this.SetSkill(SkillName.Focus, 120.0, 120.0);
        }

        public FazendeiroDoido(Serial serial)
            : base(serial)
        {
        }

        public override void Advertise()
        {
            this.Say("Seja Bem-Vindo!");  // Know yourself, and you will become a true warrior.
        }

        public override void InitBody()
        {
            this.Female = false;
            this.CantWalk = true;
            this.Race = Race.Human;

            base.InitBody();
        }

        public override void InitOutfit()
        {
            switch (Utility.Random(3))
            {
                case 0:
                    SetWearable(new FancyShirt(GetRandomHue()));
                    break;
                case 1:
                    SetWearable(new Doublet(GetRandomHue()));
                    break;
                case 2:
                    SetWearable(new Shirt(GetRandomHue()));
                    break;
            }

            SetWearable(new Shoes(GetShoeHue()));
            int hairHue = GetHairHue();

            Utility.AssignRandomHair(this, hairHue);
            Utility.AssignRandomFacialHair(this, hairHue);

            if (Body == 0x191)
            {
                FacialHairItemID = 0;
            }

            if (Body == 0x191)
            {
                switch (Utility.Random(6))
                {
                    case 0:
                        SetWearable(new ShortPants(GetRandomHue()));
                        break;
                    case 1:
                    case 2:
                        SetWearable(new Kilt(GetRandomHue()));
                        break;
                    case 3:
                    case 4:
                    case 5:
                        SetWearable(new Skirt(GetRandomHue()));
                        break;
                }
            }
            else
            {
                switch (Utility.Random(2))
                {
                    case 0:
                        SetWearable(new LongPants(GetRandomHue()));
                        break;
                    case 1:
                        SetWearable(new ShortPants(GetRandomHue()));
                        break;
                }
            }

            if (!Siege.SiegeShard)
                PackGold(100, 200);
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
    }
}
