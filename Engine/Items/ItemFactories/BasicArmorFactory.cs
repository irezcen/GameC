using System;
using System.Collections.Generic;
using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class BasicArmorFactory : ItemFactory
    {
        // produce items from BasicArmor directory
        public Item CreateAnyItem(GameSession parentSession)
        {
            List<Item> basicArmor = new List<Item>()
            {
                new SteelArmor(),
                new AntiMagicArmor(),
                new BerserkerArmor(),
                new GrowingStoneArmor()
            };
            return basicArmor[Index.RNG(0, basicArmor.Count)];
        }
        public Item CreateNonMagicItem(GameSession parentSession)
        {
            // GrowingStoneArmor only works for magic users
            List<Item> basicArmor = new List<Item>()
            {
                new SteelArmor(),
                new AntiMagicArmor(),
                new BerserkerArmor()
            };
            return basicArmor[Index.RNG(0, basicArmor.Count)];
        }
        public Item CreateNonWeaponItem(GameSession parentSession)
        {
            // BerserkerArmor only works for physical damage dealers
            List<Item> basicArmor = new List<Item>()
            {
                new SteelArmor(),
                new AntiMagicArmor(),
                new GrowingStoneArmor()
            };
            return basicArmor[Index.RNG(0, basicArmor.Count)];
        }
    }
}
