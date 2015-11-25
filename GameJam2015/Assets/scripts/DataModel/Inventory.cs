using System;
using System.Collections.Generic;

public class Inventory
{
   public Dictionary<string, Item> mItems = new Dictionary<string, Item>();

   public void ChangeItemCount(string name, int count)
   {
      if(mItems.ContainsKey(name))
      {
         mItems[name].Count += count;
         if(mItems[name].Count <= 0)
            mItems.Remove(name);
      }
      else
      {
         //if(count > 0)
            //Generate Item
      }

      /*if(mItems.ContainsKey("material"))
      {
         Material m = mItems["material"] as Material;
         if(m!= null)
             m.DoAThingOnlyMaterialCanDo();
      }*/
   }

   public int CheckItemCount(string name)
   {
      if(mItems.ContainsKey(name))
         return mItems[name].Count;
      else
         return 0;
   }

}
