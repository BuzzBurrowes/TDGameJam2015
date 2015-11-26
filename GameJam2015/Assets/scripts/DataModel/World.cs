using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World
{
   protected World()
   {
   }

   static World gWorld = null;
   static World Instance
   {
      get
      {
         if (gWorld == null)
            gWorld = new World();
         return gWorld;
      }
   }
}
