using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class crate : Item
{
   public crate()
   {
      Class = ItemClasses.consumable;
      Stackable = true;
      OneOnly = false;
   }
}

