using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Gladiator
    {

        Random random = new Random();
        public string name;
        private int baseHealth, health;
        private int baseStrength, strength;
        public Inventory inventory = new Inventory();
        public int credits;
        public ArrayList ActivePotions = new ArrayList();
        public Item EquippedHelmet;
        public Item EquippedChest;
        public Item EquippedWeapon;

        public Gladiator(string Name)
        {
            name = Name;
            baseHealth = 100;
            baseStrength = random.Next(1, 5);
            credits = 0;
            health = baseHealth;
            strength = baseStrength;
        }


        public void Attack(Enemy enemy)
        {
            Console.WriteLine("You attack!");
            int attackDamage = strength;
            Console.WriteLine("You deal {0} damage.", attackDamage);
            Console.WriteLine("--------------------");
            enemy.health -= attackDamage;


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
