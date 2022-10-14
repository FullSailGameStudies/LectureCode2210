using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public static class Extensions
    {
        public static List<BowWeapon> Bows(this Inventory backpack)
        {
            List<BowWeapon> bows = new List<BowWeapon>();
            foreach (FantasyWeapon weapon in backpack.Items)
            {
                if (weapon is BowWeapon bow)
                    bows.Add(bow);
            }
            return bows;
        }

        public static ConsoleColor GetColor(this WeaponRarity rarity)
        {
            ConsoleColor color = ConsoleColor.White;
            switch (rarity)
            {
                case WeaponRarity.Common:
                    color = ConsoleColor.DarkGray;
                    break;
                case WeaponRarity.Uncommon:
                    color = ConsoleColor.Yellow;
                    break;
                case WeaponRarity.Rare:
                    color = ConsoleColor.Magenta;
                    break;
                case WeaponRarity.Legendary:
                    color = ConsoleColor.Red;
                    break;
            }
            return color;
        }
    }
}
