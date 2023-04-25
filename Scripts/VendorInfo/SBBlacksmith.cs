using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBBlacksmith : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Tongs), 7);
                Add(typeof(IronIngot), 4);
                Add(typeof(Buckler), 25);
                Add(typeof(BronzeShield), 33);
                Add(typeof(MetalShield), 60);
                Add(typeof(MetalKiteShield), 62);
                Add(typeof(HeaterShield), 115);
                Add(typeof(WoodenKiteShield), 35);
                Add(typeof(WoodenShield), 15);
                Add(typeof(PlateArms), 94);
                Add(typeof(PlateChest), 121);
                Add(typeof(PlateGloves), 72);
                Add(typeof(PlateGorget), 52);
                Add(typeof(PlateLegs), 109);
                Add(typeof(FemalePlateChest), 113);
                Add(typeof(FemaleLeatherChest), 18);
                Add(typeof(FemaleStuddedChest), 25);
                Add(typeof(LeatherShorts), 14);
                Add(typeof(LeatherSkirt), 11);
                Add(typeof(LeatherBustierArms), 11);
                Add(typeof(StuddedBustierArms), 27);
                Add(typeof(Bascinet), 9);
                Add(typeof(CloseHelm), 9);
                Add(typeof(Helmet), 9);
                Add(typeof(NorseHelm), 9);
                Add(typeof(PlateHelm), 10);
                Add(typeof(ChainCoif), 6);
                Add(typeof(ChainChest), 71);
                Add(typeof(ChainLegs), 74);
                Add(typeof(RingmailArms), 42);
                Add(typeof(RingmailChest), 60);
                Add(typeof(RingmailGloves), 26);
                Add(typeof(RingmailLegs), 45);
                Add(typeof(BattleAxe), 13);
                Add(typeof(DoubleAxe), 26);
                Add(typeof(ExecutionersAxe), 15);
                Add(typeof(LargeBattleAxe), 16);
                Add(typeof(Pickaxe), 11);
                Add(typeof(TwoHandedAxe), 16);
                Add(typeof(WarAxe), 14);
                Add(typeof(Axe), 20);
                Add(typeof(Bardiche), 30);
                Add(typeof(Halberd), 21);
                Add(typeof(ButcherKnife), 7);
                Add(typeof(Cleaver), 7);
                Add(typeof(Dagger), 10);
                Add(typeof(SkinningKnife), 7);
                Add(typeof(Club), 8);
                Add(typeof(HammerPick), 13);
                Add(typeof(Mace), 14);
                Add(typeof(Maul), 10);
                Add(typeof(WarHammer), 12);
                Add(typeof(WarMace), 15);
                Add(typeof(HeavyCrossbow), 27);
                Add(typeof(Bow), 17);
                Add(typeof(Crossbow), 23);
                Add(typeof(CompositeBow), 25);
                Add(typeof(RepeatingCrossbow), 28);
                Add(typeof(Scepter), 20);
                Add(typeof(BladedStaff), 20);
                Add(typeof(Scythe), 19);
                Add(typeof(BoneHarvester), 17);
                Add(typeof(Scepter), 18);
                Add(typeof(BladedStaff), 16);
                Add(typeof(Pike), 19);
                Add(typeof(DoubleBladedStaff), 17);
                Add(typeof(Lance), 17);
                Add(typeof(CrescentBlade), 18);
                Add(typeof(Spear), 15);
                Add(typeof(Pitchfork), 9);
                Add(typeof(ShortSpear), 11);
                Add(typeof(BlackStaff), 11);
                Add(typeof(GnarledStaff), 8);
                Add(typeof(QuarterStaff), 9);
                Add(typeof(ShepherdsCrook), 10);
                Add(typeof(SmithHammer), 10);
                Add(typeof(Broadsword), 17);
                Add(typeof(Cutlass), 12);
                Add(typeof(Katana), 16);
                Add(typeof(Kryss), 16);
                Add(typeof(Longsword), 27);
                Add(typeof(Scimitar), 18);
                Add(typeof(VikingSword), 27);
            }
        }
    }
}
