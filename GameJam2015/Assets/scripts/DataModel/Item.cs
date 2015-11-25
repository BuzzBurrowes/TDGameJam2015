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

   private bool mStacks;
   public bool Stacks
   {
      get {return mStacks;}
      set {mStacks = value;}
   }

   public Item(string name, int count, bool stacks)
   {
      mName = name;
      mCount = count;
      mStacks = stacks;
   }

   public Item()
   {
      mName = "[unknown]";
      mCount = 0;
      mStacks = false;
   }
}
