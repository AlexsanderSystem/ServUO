using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class AnthonyQ : BaseQuest
    {
        public override bool DoneOnce { get { return true; } }

        public override object Title
        {
            get
            {
                return "Tosando Ovelhas";
            }
        }
        public override object Description
        {
            get
            {
                return "Bem-vindo, viajante. Me chamo Helga, uma modesta costureira. Tenho um pedido humilde a fazer: poderia me ajudar a tosar minhas ovelhas? Elas são a fonte de minha lã, e preciso dela para continuar tecendo minhas roupas quentes e resistentes. Em troca, ofereço meu trabalho de costura para criar peças sob medida que o manterão aquecido durante as adversidades de Hrafnsfjall. Aceita minha oferta?";
            }
        }
        public override object Refuse
        {
            get
            {
                return "...";
            }
        }
        public override object Uncomplete
        {
            get
            {
                return "Preciso de Lã para os Soldados! Faça Logo!";
            }
        }

        public override object Complete
        {
            get
            {
                return @"Ótimo trabalho, viajante. Essas ovelhas estão parecendo muito mais leves agora. Como prometido, aqui estão suas roupas quentes. Obrigado novamente pela ajuda.";
            }
        }

        public AnthonyQ()
            : base()
        {
            //this.AddObjective(new ObtainObjective(typeof(LuckyDagger), "lucky dagger", 1));
            AddObjective(new ObtainObjective(typeof(Wool), "Bolo de Lã", 10, 0xDF8));
            this.AddReward(new BaseReward(typeof(Cloak), 1, "Manto de La"));
            this.AddReward(new BaseReward(typeof(Kilt), 1, "Uma Saia de La"));
        }

        public override void OnCompleted()
        {
            this.Owner.PlaySound(this.CompleteSound);
        }

        public override void OnAccept()
        {
            base.OnAccept();
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
   
    public class Grimgor : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[] {
                    typeof(AnthonyQ),
                    //typeof(SapatoLindoQ2)
                };
            }
        }


        [Constructable]
        public Grimgor()
            : base("Helga", "")
        {
            //this.Body = 17;
            this.SetSkill(SkillName.Anatomy, 120.0, 120.0);
            this.SetSkill(SkillName.Parry, 120.0, 120.0);
            this.SetSkill(SkillName.Healing, 120.0, 120.0);
            this.SetSkill(SkillName.Tactics, 120.0, 120.0);
            this.SetSkill(SkillName.Swords, 120.0, 120.0);
            this.SetSkill(SkillName.Focus, 120.0, 120.0);
        }

        public Grimgor(Serial serial)
            : base(serial)
        {
        }

        public override void Advertise()
        {
            this.Say("Sonho com o dia da que poderemos ter paz...");  // Know yourself, and you will become a true warrior.
        }

        public override void InitBody()
        {
            this.Female = true;
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
