using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Gladiator
    {
        Random random = new Random();
        public string name;
        public int baseHealth, health;
        public int baseStrength, strength;
        public Inventory inventory = new Inventory();

        public Gladiator(string Name)
        {
            name = Name;
            baseHealth = 100;
            baseStrength = random.Next();
        }


        public void attack(Enemy enemy)
        {

            Console.WriteLine("You attack!");
            int attackDamage = strength;
            Console.WriteLine("You deal {0} damage.", attackDamage);
            enemy.health -= attackDamage;


        }
        public void equipItem(Item item)
        {
            health = baseHealth + item.Health;
            strength = baseStrength + item.Strength;
        }
        public void checkInventory()
        {
            foreach (int i in inventory.inventoryList) Console.WriteLine(inventory.inventoryList[i]);
        }

    }
}
