using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBFisherman : SBInfo
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
                Add(typeof(RawFishSteak), 1);
                Add(typeof(Fish), 1);
                Add(typeof(SmallFish), 1);
                Add(typeof(FishingPole), 20);
            }
        }
    }
}
