using System;
using System.Collections.Generic;

class CollectableItem
{
   private string mName;
   public string Name
   {
      get { return mName; }
      set { mName = value; }
   }

   public CollectableItem(string name)
   {
      mName = name;
   }
}
