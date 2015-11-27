using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableController : MonoBehaviour 
{
   public string ItemType;
   
   public DictionaryOfStringAndString Props = new DictionaryOfStringAndString();

   void Start() 
   {
	
   }
	
   void Update()
   {
	
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      ItemCollector collector = collider.gameObject.GetComponent(typeof(ItemCollector)) as ItemCollector;
      if (collector != null)
      {
         if (collector.TryToCollectItem(ItemType, Props))
         {
            Destroy(gameObject);
         }
      }
   }
}
