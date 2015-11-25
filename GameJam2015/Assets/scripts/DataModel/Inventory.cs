using System;
using System.Collections.Generic;

public class Inventory
{
   public List<Item> mItems = new List<Item>();

   public bool TryAddItem(string name, IDictionary<string, string> props)
   {
      Type elementType = Type.GetType(name);
      if (elementType != null)
      {
         Item item = Activator.CreateInstance(elementType) as Item;
         if (item != null)
         {
            if (item.Stackable)
            {
               // search list for existing inventory of the same type and try to stack...
               foreach(Item i in mItems)
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

            mItems.Add(item);
            return true;
         }
      }
  
      return false;
   }

   public void ConsumeItem(string name, int count)
   {
      for (int i = mItems.Count - 1; i > -1 && count > 0; i--)
      {
         if (mItems[i].Name == name)
         {
            if (mItems[i].Count > count)
            {
               mItems[i].Count -= count;
               return;
            }
            count -= mItems[i].Count;
            mItems.RemoveAt(i);
         }
      }
   }

   public int CheckItemCount(string name)
   {
      int count = 0;
      foreach (Item i in mItems)
      {
         if (i.Name == name)
            count += i.Count;
      }
      return count;
   }

}
