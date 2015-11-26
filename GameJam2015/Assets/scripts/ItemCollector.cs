using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour 
{
   ItemInventory mInventory = new ItemInventory();

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
