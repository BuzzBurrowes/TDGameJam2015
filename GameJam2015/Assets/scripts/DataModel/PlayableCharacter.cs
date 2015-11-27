using System;
using System.Collections.Generic;

public class PlayableCharacter
{
   ItemInventory mInventory = new ItemInventory();
   public ItemInventory Inventory
   {
      get { return mInventory; }
      set { mInventory = value; }
   }

   public bool TryToCollectItem(Item item)
   {
      return mInventory.TryAddItem(item);
   }
}
