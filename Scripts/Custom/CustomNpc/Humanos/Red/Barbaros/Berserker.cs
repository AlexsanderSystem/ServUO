using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
[CorpseName("Corpo de um Berserker")]
public class Berserker : BaseCreature
{
private static readonly Type[] ArmorTypes =
{
typeof(BoneChest),
typeof(BoneLegs),
};


private static readonly Type[] AxeTypes =
    {
        typeof(Axe),
        typeof(BattleAxe),
        typeof(DoubleAxe),
        typeof(Hatchet),
        typeof(WarAxe)
    };

    [Constructable]
    public Berserker() : base(AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4)
    {
        Title = "Berserker";
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
        Fame = 5000;
        Karma = -10000;
        VirtualArmor = 30;

        // Adiciona uma armadura aleatória
        Type armorType = ArmorTypes[Utility.Random(ArmorTypes.Length)];
        AddItem((Item)Activator.CreateInstance(armorType));

        // Adiciona um machado aleatório
        Type axeType = AxeTypes[Utility.Random(AxeTypes.Length)];
        BaseWeapon weapon = (BaseWeapon)Activator.CreateInstance(axeType);

        weapon.Movable = false;
        AddItem(weapon);

        SetWearable(new Boots(), Utility.RandomNeutralHue(), dropChance: 1);

        SetWearable(new Kilt(), Utility.RandomNeutralHue(), dropChance: 1);

       SetWearable((Item)Activator.CreateInstance(typeof(PolarBearMask)), dropChance: 0.03);
    }

public override void OnDamage(int amount, Mobile from, bool willKill)
{
    base.OnDamage(amount, from, willKill);

    if (willKill || amount < 5 || Utility.RandomBool())
        return;

    if (Combatant == null || Combatant.Deleted || Combatant.Map != Map || !Combatant.Alive)
        return;

    PlaySound(0x14D);

    Emote("*O berserker entra em um frenesi de combate!*");

    int bonus = 50;

    Str += bonus;
    Dex += bonus;
    Hits += bonus;


    Timer.DelayCall(TimeSpan.FromSeconds(15), () =>
    {
        int debuff = 35;


        Str -= debuff;
        Dex -= debuff;
        Hits -= debuff;


        Emote("*O berserker acalma seus instintos e volta ao normal*");
    });
}

        public override bool AlwaysMurderer => true;


    public Berserker(Serial serial) : base(serial)
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
