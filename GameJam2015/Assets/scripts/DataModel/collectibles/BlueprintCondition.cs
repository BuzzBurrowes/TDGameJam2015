using System;
using System.Collections.Generic;

public class BlueprintCondition
{
   private string mName;
   public string Name
   {
      get { return mName; }
   }

   private int mCount;
   public int Count
   {
      get { return Count;  }
   }
   
   public BlueprintCondition(string name, int count)
   {
      mName = name;
      mCount = count;
   }

   public bool Check(ItemInventory inventory)
   {
      return (inventory.CheckItemCount(mName) >= mCount);
   }
}