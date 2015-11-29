using System;
using System.Collections.Generic;

public class ItemInventory
{
   public List<Item> mEquipment   = new List<Item>();
   public List<Item> mConsumables = new List<Item>();
   public List<Item> mMaterials   = new List<Item>();
   public List<Item> mBlueprints  = new List<Item>();
   public List<Item> mKeyItems    = new List<Item>();

   public bool TryAddItem(Item item)
   {
      List<Item> itemList;
      switch (item.Class)
      {
         case Item.ItemClasses.consumable: itemList = mConsumables; break;
         case Item.ItemClasses.blueprint:  itemList = mBlueprints;  break;
         case Item.ItemClasses.key:        itemList = mKeyItems;    break;
         case Item.ItemClasses.weapon:     itemList = mEquipment;     break;
         default: throw new ArgumentException("Unrecognized item class!", item.Class.ToString());
      }

      if (item.Stackable)
      {
         // search list for existing inventory of the same type and try to stack...
         foreach(Item i in itemList)
         {
            if (i.GetType() == item.GetType())
            {
               // can we stack here?
               if (i.Add(item))
                  return true;
            }
         }
      }
      
      if (item.OneOnly)
      {
         // search list for existing inventory of the same type and try to stack...
         foreach (Item i in itemList)
         {
            if (i.GetType() == item.GetType())
            {
               return false;
            }
         }
      }

      // if we get here we can't stack, or all stacks are full...
      itemList.Add(item);
      return true;
   }

   public void ConsumeItem(string name, int count)
   {
      for (int i = mConsumables.Count - 1; i > -1 && count > 0; i--)
      {
         if (mConsumables[i].Name == name)
         {
            if (mConsumables[i].Count > count)
            {
               mConsumables[i].Count -= count;
               return;
            }
            count -= mConsumables[i].Count;
            mConsumables.RemoveAt(i);
         }
      }
   }

   public int CheckItemCount(string name)
   {
      int count = 0;
      foreach (Item i in mConsumables)
      {
         if (i.Name == name)
            count += i.Count;
      }
      return count;
   }

}
