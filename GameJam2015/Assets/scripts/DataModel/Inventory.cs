using System;
using System.Collections.Generic;

public class Inventory
{
   public List<Item> mConsumableItems = new List<Item>();
   public List<Item> mBlueprints = new List<Item>();
   public List<Item> mKeyItems = new List<Item>();

   public bool TryAddItem(string name, IDictionary<string, string> props)
   {
      Type elementType = Type.GetType(name);
      if (elementType != null)
      {
         // which list would this go on?
         Item item = Activator.CreateInstance(elementType) as Item;
         if (item != null)
         {
            List<Item> itemList;
            if (item.Consumable)
               itemList = mConsumableItems;
            else if (name == "blueprint")
               itemList = mBlueprints;
            else
               itemList = mKeyItems;    
            if (item.Stackable)
            {
               // search list for existing inventory of the same type and try to stack...
               foreach(Item i in mConsumableItems)
               {
                  if (i.GetType() == elementType)
                  {
                     // can we stack here?
                     if (i.Add(props))
                        return true;
                  }
               }
            }
            // if we get here we can't stack, or all stacks are full...
            if (!item.Init(name, props))
               return false;

            itemList.Add(item);
            return true;
         }
      }
  
      return false;
   }

   public void ConsumeItem(string name, int count)
   {
      for (int i = mConsumableItems.Count - 1; i > -1 && count > 0; i--)
      {
         if (mConsumableItems[i].Name == name)
         {
            if (mConsumableItems[i].Count > count)
            {
               mConsumableItems[i].Count -= count;
               return;
            }
            count -= mConsumableItems[i].Count;
            mConsumableItems.RemoveAt(i);
         }
      }
   }

   public int CheckItemCount(string name)
   {
      int count = 0;
      foreach (Item i in mConsumableItems)
      {
         if (i.Name == name)
            count += i.Count;
      }
      return count;
   }

}
