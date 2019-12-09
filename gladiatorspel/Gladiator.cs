using System;
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
            AttackDamage = strength;
            Console.WriteLine("You deal {0} damage.", AttackDamage);
            Console.WriteLine("--------------------");
            enemy.health -= AttackDamage;
        }
        public void EquipItem(Item item)
        {
            health = baseHealth + item.BonusHealth;
            strength = baseStrength + item.BonusStrength;
        }
        public void CheckInventory()
        {
            foreach (Item item in inventory.inventoryList) Console.WriteLine(item.Name);
        }

    }
}
