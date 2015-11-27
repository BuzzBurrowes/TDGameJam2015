using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CollectableController : MonoBehaviour 
{
   public DictionaryOfStringAndString ItemInfo = new DictionaryOfStringAndString();
   Item mItem;
   
   void Start() 
   {
      try
      {
         Type elementType = Type.GetType(ItemInfo["itemtype"]);
         if (elementType != null)
         {
            mItem = Activator.CreateInstance(elementType) as Item;
            mItem.Setup(ItemInfo);
         }
      }
      catch
      {
         throw new ArgumentException("Couldn't setup map item!", "Bad 'itemtype'");
      }
   }

   void Update()
   {
	
   }

   public void SetDescription(IDictionary<string, string> props)
   {
      foreach (string s in props.Keys)
         ItemInfo[s] = props[s];
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      ItemCollector collector = collider.gameObject.GetComponent(typeof(ItemCollector)) as ItemCollector;
      if (collector != null)
      {
         if (collector.TryToCollectItem(mItem))
         {
            Destroy(gameObject);
         }
      }
   }
}
