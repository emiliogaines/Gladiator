using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Gladiator
    {
        readonly Random random = new Random();
        public string name;
        public int baseHealth, health;
        public int baseStrength, strength;
        public Inventory inventory = new Inventory();
        public int credits;

        public int AttackDamage { get; set; }

        public ArrayList ActivePotions = new ArrayList();
        public Item EquippedHelmet;
        public Item EquippedChest;
        public Item EquippedWeapon;

        public Gladiator(string Name)
        {
            name = Name;
            baseHealth = 100;
            baseStrength = random.Next(5, 11);
            credits = 0;
            health = baseHealth;
            strength = baseStrength;
        }


        public void Attack(Enemy enemy)
        {
            Console.WriteLine("You attack!");
            AttackDamage = strength;
            Console.WriteLine("You deal {0} damage.", AttackDamage);
            Console.WriteLine("--------------------");
            enemy.health -= AttackDamage;
        }
        public void EquipItem(Item item)
        {
            switch (item.Type)
            {
                case ItemType.HELMET:
                    EquippedHelmet = item;
                    break;
                case ItemType.CHEST:
                    EquippedChest = item;
                    break;
                case ItemType.WEAPON:
                    EquippedWeapon = item;
                    break;

            }
        }
        public void UsePotion(Potions potion)
        {
            health = GetHealth();
            strength = GetStrength();
            ActivePotions.Add(potion);

        }
        public void RemoveActivePotion()
        {
            ActivePotions.Clear();
        }
        public int GetHealth()
        {
            int bonusHealth = 0;
            foreach (Potions potion in ActivePotions)
            {
                bonusHealth += potion.BonusHealth;
            }
            return health + bonusHealth;
        }
        public int GetStrength()
        {
            int bonusStrength = 0;
            foreach (Potions potion in ActivePotions)
            {
                bonusStrength += potion.BonusStrength;
            }
            return strength + bonusStrength;
        }
        public void CheckInventory()
        {
            foreach (Item item in inventory.inventoryList) Console.WriteLine(item.Name);
        }

    }
}
