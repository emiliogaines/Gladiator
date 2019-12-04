using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Inventory
    {
        public ArrayList inventoryList = new ArrayList();

        public void addToInventory(item item)
        {
            inventoryList.Add(item);
        }
    }
}
