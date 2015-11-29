using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMenuController : MonoBehaviour 
{
   PlayableCharacter mPlayableCharacter = null;
   public PlayableCharacter Character
   {
      get { return mPlayableCharacter; }
      set { mPlayableCharacter = value; _SetupPanelsForCharacter(); }
   }

   public Canvas InventoryMenu;

   GameObject mEquipmentPanel;
   GameObject mConsumablesPanel;
   GameObject mKeyItemsPanel;
   GameObject mMaterialsPanel;

   void Start() 
   {
      _ConnectToPanels();
   }

   void _ConnectToPanels()
   {
      mEquipmentPanel = GameObject.Find("EquipmentPanel");
      mConsumablesPanel = GameObject.Find("ConsumablesPanel");
      mKeyItemsPanel = GameObject.Find("KeyItemsPanel");
      mMaterialsPanel = GameObject.Find("MaterialsPanel");
   }

   public void Show(bool show)
   {
      if (show && !InventoryMenu.gameObject.activeInHierarchy)
         InventoryMenu.gameObject.SetActive(true);
      else if (!show && InventoryMenu.gameObject.activeInHierarchy)
         InventoryMenu.gameObject.SetActive(false);
   }

   void Update()
   {
      if (Input.GetButtonDown("InventoryMenu"))
      {
         if (!InventoryMenu.gameObject.activeInHierarchy)
            Show(true);
         else
            Show(false);
      }
   }

   public void ShowItemList(int type)
   {
      // hide all...
      mEquipmentPanel   .SetActive(false);
      mConsumablesPanel .SetActive(false);
      mKeyItemsPanel    .SetActive(false);
      mMaterialsPanel   .SetActive(false);

      switch (type)
      {
         case 0:
            mEquipmentPanel.SetActive(true);
            break;
         case 1:
            mConsumablesPanel.SetActive(true);
            break;
         case 2:
            mKeyItemsPanel.SetActive(true);
            break;
         case 3:
            mMaterialsPanel.SetActive(true);
            break;
      }
   }

   private void _SetupPanelsForCharacter()
   {
      if (mEquipmentPanel == null)
         _ConnectToPanels();

      mEquipmentPanel.GetComponent<InventoryPanelController>().ItemList = mPlayableCharacter.Inventory.mEquipment;
      mConsumablesPanel.GetComponent<InventoryPanelController>().ItemList = mPlayableCharacter.Inventory.mConsumables;
      mKeyItemsPanel.GetComponent<InventoryPanelController>().ItemList = mPlayableCharacter.Inventory.mKeyItems;
      mMaterialsPanel.GetComponent<InventoryPanelController>().ItemList = mPlayableCharacter.Inventory.mMaterials;
   }
}
