using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace CustomNpc
{
    [CorpseName("Corpo de um Sapo do Gelo")]
    public class IceFrog : BaseCreature
    {
        [Constructable]
        public IceFrog() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Sapo do Gelo";
            Body = 81; // Define o ID do corpo do NPC (corpo do sapo)
            Hue = 0; // Define a cor do NPC (cor do sapo do gelo)

            SetStr(5, 10); // Define a força do NPC
            SetDex(45, 65); // Define a destreza do NPC
            SetInt(6, 10); // Define a inteligência do NPC

            SetHits(10, 60); // Define os pontos de vida do NPC
            SetDamage(1, 2); // Define o dano do NPC

            SetSkill(SkillName.MagicResist, 5.0, 10.0); // Define a resistência à magia do NPC
            SetSkill(SkillName.Tactics, 5.0, 10.0); // Define a habilidade tática do NPC
            SetSkill(SkillName.Wrestling, 5.0, 10.0); // Define a habilidade de luta do NPC

            Fame = 50; // Define a fama do NPC
            Karma = -50; // Define o karma do NPC

            VirtualArmor = 0; // Define a armadura virtual do NPC

            // Define os itens que o NPC vai deixar cair ao morrer
            PackItem(new RawFishSteak()); // Peixe cru
            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 22.1;
        }

        public IceFrog(Serial serial) : base(serial)
        {
        }

        //public override bool HandlesOnMovement { get { return true; } }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            // Verifica se o NPC foi atacado
            if (Combatant != null && !Combatant.Deleted && !Frozen && InRange(Combatant, 5) && Utility.RandomDouble() < 0.5)
            {
                Frozen = true;
                this.Say("*O sapo foge pulando*"); // Fala uma mensagem quando fugir

                // Define uma nova posição aleatória para o NPC se mover
                Point3D newPos = new Point3D(X + Utility.RandomMinMax(-3, 3), Y + Utility.RandomMinMax(-3, 3), Z);

                // Move o NPC para a nova posição
                this.MoveToWorld(newPos, Map);

                Frozen = false;
            }

            base.OnMovement(m, oldLocation);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // versão
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
