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

   private bool mConsumable;
   public bool Consumable
   {
      get { return mConsumable; }
      set { mConsumable = value; }
   }
   public Item(string name, int count, bool stackable, bool consumable)
   {
      mName = name;
      mCount = count;
      mStackable = stackable;
      mConsumable = consumable;
   }

   public Item()
   {
      mName = "[unknown]";
      mCount = 0;
      mStackable = false;
      mConsumable = true;
   }

   public bool Add(IDictionary<string, string> props)
   {
      if (props.ContainsKey("count"))
         mCount += int.Parse(props["count"]);
      else
         mCount++;
     
      // give any subclass a stab at deciphering the props...
      _Add(props);
      return true;
   }

   protected virtual bool _Add(IDictionary<string, string> props) { return true; }

   public bool Init(string name, IDictionary<string, string> props)
   {
      mName = name;
      return Add(props);
   }
}
