using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Program
    {
        private static Dictionary<string, Dictionary<string, long>> bagOfWealth;
        private static long bagAmount;
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bagOfWealth = new Dictionary<string, Dictionary<string, long>>();
            long goldAmount = 0;
            long gemAmount = 0;
            long cashAmount = 0;
            bagAmount = 0;

            for (int i = 0; i < items.Length; i += 2)
            {
                string item = items[i];
                long itemAmount = long.Parse(items[i + 1]);

                if (bagAmount + itemAmount > bagCapacity)
                {
                    continue;
                }

                if (item.ToLower() == "gold")
                {
                    goldAmount = AddGoldToBag(item, itemAmount, goldAmount);
                }
                else if (item.ToLower().EndsWith("gem") && (gemAmount + itemAmount) <= goldAmount && item.Length >= 4)
                {
                    gemAmount = AddItemToBag("Gem", item, itemAmount, gemAmount);
                }
                else if (item.Length == 3 && (cashAmount + itemAmount) <= gemAmount)
                {
                    cashAmount = AddItemToBag("Cash", item, itemAmount, cashAmount);
                }
            }

            PrintBagContents();
        }

        private static void PrintBagContents()
        {
            foreach (var item in bagOfWealth.OrderByDescending(k => k.Value.Values.Sum()))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(g => g.Value)}");
                foreach (var pair in item.Value.OrderByDescending(k => k.Key))
                {
                    Console.WriteLine($"##{pair.Key} - {pair.Value}");
                }
            }
        }

        private static long AddGoldToBag(string item, long itemAmount, long goldAmount)
        {
            if (!bagOfWealth.ContainsKey(item))
            {
                bagOfWealth.Add(item, new Dictionary<string, long>());
                bagOfWealth[item].Add(item, 0);
            }

            bagOfWealth["Gold"]["Gold"] += itemAmount;
            goldAmount += itemAmount;
            bagAmount += itemAmount;
            return goldAmount;
        }

        private static long AddItemToBag(string key, string item, long currentItemAmount, long itemAmount)
        {
            if (!bagOfWealth.ContainsKey(key))
            {
                bagOfWealth.Add(key, new Dictionary<string, long>());
            }

            if (!bagOfWealth[key].ContainsKey(item))
            {
                bagOfWealth[key].Add(item, 0);
            }

            bagOfWealth[key][item] += currentItemAmount;
            itemAmount += currentItemAmount;
            bagAmount += currentItemAmount;
            return itemAmount;
        }
    }
}