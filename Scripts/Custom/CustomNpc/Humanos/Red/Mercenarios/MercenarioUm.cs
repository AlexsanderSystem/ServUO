using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
[CorpseName("Corpo de um MercenarioUm")]
public class MercenarioUm : BaseCreature
{
private static readonly Type[] AxeTypes =
    {
        typeof(Longsword),
        typeof(VikingSword),
        typeof(WarAxe)
    };

    [Constructable]
    public MercenarioUm() : base(AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4)
    {
        Title = "Mercenario Padrão";
        SpeechHue = Utility.RandomDyedHue();
        Hue = Utility.RandomSkinHue();
        Body = Female ? 0x191 : 0x190;

        if (Female)
            Name = NameList.RandomName("female");
        else
            Name = NameList.RandomName("male");

        SetStr(120);
        SetDex(100);
        SetInt(25);
        SetHits(200);
        SetDamage(16, 26);
        SetDamageType(ResistanceType.Physical, 100);
        SetResistance(ResistanceType.Physical, 25, 35);
        SetResistance(ResistanceType.Fire, 10, 20);
        SetResistance(ResistanceType.Cold, 10, 20);
        SetResistance(ResistanceType.Poison, 10, 20);
        SetResistance(ResistanceType.Energy, 10, 20);
        SetSkill(SkillName.MagicResist, 25.1, 30.0);
        SetSkill(SkillName.Tactics, 80.1, 90.0);
        SetSkill(SkillName.Anatomy, 80.1, 90.0);
        SetSkill(SkillName.Swords, 50, 90.0);
        Fame = 0;
        Karma = -10000;
        VirtualArmor = 30;

        // Adiciona uma arma aleatório
        Type axeType = AxeTypes[Utility.Random(AxeTypes.Length)];
        BaseWeapon weapon = (BaseWeapon)Activator.CreateInstance(axeType);

            Item shield = new MetalShield();
            shield.Hue = 0x973;
            shield.Movable = false;
            AddItem(shield);

            Item helmet = new NorseHelm();
            helmet.Hue = 1109;
            helmet.Movable = false;
            AddItem(helmet);

            Item armor = new RingmailChest();
            armor.Hue = 0x973;
            armor.Movable = false;
            AddItem(armor);

            Item legs = new RingmailLegs();
            legs.Hue = 0x973;
            legs.Movable = false;
            AddItem(legs);

            Item gloves = new RingmailGloves();
            gloves.Hue = 0x973;
            gloves.Movable = false;
            AddItem(gloves);

            Item boots = new Boots();
            boots.Hue = 0x973;
            boots.Movable = false;
            AddItem(boots);

            Item cloak = new Cloak();
            cloak.Hue = 1109;
            cloak.Movable = false;
            AddItem(cloak);

            Item sword = new VikingSword();
            sword.Hue = 0x973;
            sword.Movable = false;
            AddItem(sword);

    }

public override void OnDamage(int amount, Mobile from, bool willKill)
{
    base.OnDamage(amount, from, willKill);

    if (willKill || amount < 5 || Utility.RandomBool())
        return;

    if (Combatant == null || Combatant.Deleted || Combatant.Map != Map || !Combatant.Alive)
        return;

    PlaySound(0x14D);

    Emote("*Em posição de Combate!*");

    int bonus = 50;

    Str += bonus;


    Timer.DelayCall(TimeSpan.FromSeconds(20), () =>
    {
        int debuff = 35;


        Str -= debuff;
        Dex -= debuff;
        Hits -= debuff;


        Emote("*Cansado em manter o escudo levantado*");
    });
}

        public override bool AlwaysMurderer => true;


    public MercenarioUm(Serial serial) : base(serial)
    {
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
    }
}
}
