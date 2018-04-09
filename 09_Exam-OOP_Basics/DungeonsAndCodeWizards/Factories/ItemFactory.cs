using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            if (itemName != "PoisonPotion" && itemName != "HealthPotion" && itemName != "ArmorRepairKit")
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            Item item = null;
            if (itemName == "PoisonPotion")
            {
                item = new PoisonPotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                item = new ArmorRepairKit();
            }

            return item;
        }
    }
}
