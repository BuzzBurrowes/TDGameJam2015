using System;
using System.Collections.Generic;

public class Item
{
   private string mName;
   public string Name
   {
      get { return mName; }
      set { mName = value; }
   }

   private int mCount;
   public int Count
   {
      get { return mCount; }
      set { mCount = value; }
   }

   private bool mStackable;
   public bool Stackable
   {
      get {return mStackable;}
      set {mStackable = value;}
   }

   public Item(string name, int count, bool stackable)
   {
      mName = name;
      mCount = count;
      mStackable = stackable;
   }

   public Item()
   {
      mName = "[unknown]";
      mCount = 0;
      mStackable = false;
   }

   virtual public bool Add(IDictionary<string, string> props)
   {
      if (props.ContainsKey("count"))
         mCount += int.Parse(props["count"]);
      else
         mCount++;
      return true;
   }

   virtual public bool Init(string name, IDictionary<string, string> props)
   {
      mName = name;
      return Add(props);
   }
}
