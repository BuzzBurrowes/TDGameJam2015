﻿using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
   public Canvas InventoryMenu;

   void Start() 
   {
	
   }
	
   void Update()
   {
      if (Input.GetButtonDown("InventoryMenu"))
      {
         if (!InventoryMenu.gameObject.activeInHierarchy)
            InventoryMenu.gameObject.SetActive(true);
         else
            InventoryMenu.gameObject.SetActive(false);
      }
   }
}
