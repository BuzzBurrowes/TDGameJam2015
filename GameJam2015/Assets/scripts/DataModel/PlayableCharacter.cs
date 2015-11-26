using System;
using System.Collections.Generic;

class PlayableCharacter
{
   ItemInventory mInventory = new ItemInventory();
   public ItemInventory Inventory
   {
      get { return mInventory; }
      set { mInventory = value; }
   }
}
