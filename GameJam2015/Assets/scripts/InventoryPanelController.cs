using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryPanelController : MonoBehaviour 
{
   Vector2 TopLeft = new Vector2(8,-7);
   int ColumnOffset = 8;
   int RowOffset = -8;

   List<Item> mItemList;
   List<ItemButtonController> mItemButtons = new List<ItemButtonController>();
   public List<Item> ItemList
   {
      get { return mItemList; }
      set { mItemList = value; }
   }

   void Update()
   {
      if (mItemList != null)
      {
         bool buttonsNeedReflow = false;

         // look for items without buttons...
         foreach (Item i in mItemList)
         {
            ItemButtonController foundController = null;
            foreach (ItemButtonController c in mItemButtons)
            {
               if (c.theItem == i)
               {
                  foundController = c;
                  break;
               }
            }
            if (foundController == null)
            {
               // make a new button for this item!
               buttonsNeedReflow = true;
               _MakeButtonForItem(i);
            }
         }

         // see if there are any buttons whose items are dead...
         for (int i = mItemButtons.Count - 1; i > -1; i--)
         {
            if (!mItemList.Contains(mItemButtons[i].theItem))
            {
               GameObject itemToKill = mItemButtons[i].gameObject;
               mItemButtons.RemoveAt(i);
               DestroyObject(itemToKill);
               buttonsNeedReflow = true;
            }
         }

         if (buttonsNeedReflow)
         {
            _ReflowButtons();
         }
      }
   }

   void _ReflowButtons()
   {
      for (int i = 0; i < mItemList.Count; i++)
      {
         int row = i / 7;
         int column = i % 7;

         RectTransform rt = mItemButtons[i].transform as RectTransform;
         rt.anchorMin = new Vector2(0, 1);
         rt.anchorMax = new Vector2(0, 1);
         float x = TopLeft.x + (column * ColumnOffset);
         float y = TopLeft.y + (row * RowOffset);
         rt.anchoredPosition = new Vector2(x, y);
      }
   }

   void _MakeButtonForItem(Item item)
   {
      UnityEngine.Object buttonPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefabs/menus/ItemButton.prefab", typeof(GameObject));
      GameObject itemButton = (GameObject)GameObject.Instantiate(buttonPrefab);
      itemButton.transform.SetParent(transform, false);
      ItemButtonController controller = itemButton.GetComponent<ItemButtonController>();
      controller.theItem = item;
      mItemButtons.Add(controller);
   }
}
