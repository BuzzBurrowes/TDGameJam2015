using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableController : MonoBehaviour 
{
   public string ItemType;
   
   public Dictionary<string, string> Props = new Dictionary<string, string>();

   void Start() 
   {
	
   }
	
   void Update()
   {
	
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      ItemCollector collector = collider.gameObject.GetComponent<ItemCollector>();
      if (collector != null)
      {
         if (collector.TryToCollectItem(ItemType, Props))
         {
            Destroy(gameObject);
         }
      }
   }
}
