using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World
{
   protected World()
   {
   }

   static World gWorld = null;
   public static World Instance
   {
      get
      {
         if (gWorld == null)
            gWorld = new World();
         return gWorld;
      }
   }

   PlayableCharacter mLocalPlayer = new PlayableCharacter();
   public PlayableCharacter LocalPlayer
   {
      get { return mLocalPlayer; }
   }
}
