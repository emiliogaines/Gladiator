using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Gladiator
    {
<<<<<<< HEAD
        readonly Random random = new Random();
        public string name; 
        public int baseHealth, health; 
        public int baseStrength, strength; 
=======
        Random random = new Random();
        public string name;
        public int baseHealth, health;
        public int baseStrength, strength;
        public Inventory inventory = new Inventory();
>>>>>>> 4a314679024dfc189b5367f9eb6446794f083883

        public Gladiator(string Name)
        {
            name = Name;
            baseHealth = 100;
            baseStrength = random.Next();
        }


        public void Attack(Enemy enemy)
        {

            Console.WriteLine("You attack!");
            int attackDamage = strength;
            Console.WriteLine("You deal {0} damage.", attackDamage);
            enemy.health -= attackDamage;


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
