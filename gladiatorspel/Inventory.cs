﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Inventory
    {
        public ArrayList inventoryList = new ArrayList();

        public void addToInventory(Item item)
        {
            inventoryList.Add(item);
        }
    }
}