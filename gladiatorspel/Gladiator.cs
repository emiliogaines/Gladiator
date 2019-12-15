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
        public int baseHealth;
        public int baseStrength;
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
            baseHealth = 30;
            baseStrength = random.Next(5, 11);
            credits = 0;
        }

        public int Attack(Enemy enemy)
        {
            AttackDamage = GetStrength();
            enemy.health = Math.Max(0, enemy.health - AttackDamage);
            return AttackDamage;
        }
        public void EquipItem(Item item)
        {
            if (item == null) return;
            switch (item.Type)
            {
                case ItemType.HELMET:
                    if (EquippedHelmet != null) inventory.AddToInventory(EquippedHelmet);
                    EquippedHelmet = item;
                    break;
                case ItemType.CHEST:
                    if (EquippedChest != null) inventory.AddToInventory(EquippedChest);
                    EquippedChest = item;
                    break;
                case ItemType.WEAPON:
                    if (EquippedWeapon != null) inventory.AddToInventory(EquippedWeapon);
                    EquippedWeapon = item;
                    break;
                case ItemType.POTION_HEALTH:
                    UsePotion((Potions)item);
                    break;
                case ItemType.POTION_STRENGTH:
                    UsePotion((Potions)item);
                    break;
            }
            inventory.inventoryList.Remove(item);
        }
        public void UsePotion(Potions potion)
        {
            ActivePotions.Add(potion);
        }
        public void RemoveActivePotion()
        {
            foreach (Potions potion in ActivePotions)
            {
                if (potion.Type == ItemType.POTION_STRENGTH)
                {
                    ActivePotions.Remove(potion);
                }
            }
        }
        public int GetHealth()
        {
            int bonusHealth = 0;
            foreach (Potions potion in ActivePotions)
            {
                bonusHealth += potion.BonusHealth;
            }
            if (EquippedHelmet != null) bonusHealth += EquippedHelmet.BonusHealth;
            if (EquippedChest != null) bonusHealth += EquippedChest.BonusHealth;
            if (EquippedWeapon != null) bonusHealth += EquippedWeapon.BonusHealth;
            return Math.Max(0, baseHealth + bonusHealth);
        }
        public int GetStrength()
        {
            int bonusStrength = 0;
            foreach (Potions potion in ActivePotions)
            {
                bonusStrength += potion.BonusStrength;
            }
            if (EquippedHelmet != null) bonusStrength += EquippedHelmet.BonusStrength;
            if (EquippedChest != null) bonusStrength += EquippedChest.BonusStrength;
            if (EquippedWeapon != null) bonusStrength += EquippedWeapon.BonusStrength;
            return baseStrength + bonusStrength;
        }
        public void DealDamage(int damage)
        {
            baseHealth -= damage;
        }
        public void CheckInventory()
        {
            foreach (Item item in inventory.inventoryList) Console.WriteLine(item.Name);
        }

    }
}
