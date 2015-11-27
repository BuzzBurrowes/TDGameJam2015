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

   public bool TryToCollectItem(string itemType, Dictionary<string, string> props)
   {
      return mInventory.TryAddItem(itemType, props);
   }
}
