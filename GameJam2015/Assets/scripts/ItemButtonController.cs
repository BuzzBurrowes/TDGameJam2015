using UnityEngine;
using System.Collections;

public class ItemButtonController : MonoBehaviour 
{
   Item mItem;
   public Item theItem
   {
      get { return mItem; }
      set { mItem = value; }
   }
}
