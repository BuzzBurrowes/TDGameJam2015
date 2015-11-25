using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour 
{
   Inventory mInventory = new Inventory();

   void Start() 
   {
	
   }
	
   void Update()
   {
	
   }

   public bool TryToCollectItem(string itemType, Dictionary<string, string> props)
   {
      return mInventory.TryAddItem(itemType, props);
   }
}
