using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour 
{
   void Start() 
   {
	
   }
	
   void Update()
   {
	
   }

   public bool TryToCollectItem(string itemType, Dictionary<string, string> props)
   {
      Debug.Log("Tried to collect item of type: " + itemType);
      return true;
   }
}
