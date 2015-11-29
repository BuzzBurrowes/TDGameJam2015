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

   private bool mOneOnly;
   public bool OneOnly
   {
      get { return mOneOnly; }
      set { mOneOnly = value; }
   }

   public enum ItemClasses
   {
      unknown,
      consumable,
      weapon,
      blueprint,
      key
   }

   private ItemClasses mClass;
   public ItemClasses Class
   {
      get { return mClass; }
      set { mClass = value; }
   }

   public Item()
   {
      mName = "[unknown]";
      mCount = 0;
      mStackable = false;
      mClass = ItemClasses.unknown;
      mOneOnly = false;
   }

   public bool Add(Item i)
   {
      mCount += i.Count;
     
      // give any subclass a stab at deciphering the props...
      _Add(i);

      return true;
   }

   protected virtual void _Add(Item item) { }

   public bool Setup(IDictionary<string, string> props)
   {
      if (props.ContainsKey("count"))
         mCount = int.Parse(props["count"]);
      return _Setup(props);
   }

   // override in subclasses to populate class specific properties from 
   // props...
   protected virtual bool _Setup(IDictionary<string, string> props)
   {
      return true;
   }
}
