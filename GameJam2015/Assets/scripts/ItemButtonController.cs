using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemButtonController : MonoBehaviour 
{
   Item mItem;
   Text mText;

   public Item theItem
   {
      get { return mItem; }
      set { mItem = value; }
   }

   void Update()
   {
      if (mText == null)
      {
         mText = transform.Find("Text").GetComponent<Text>();
      }

      if (mItem != null && mItem.Count > 1)
      {
         mText.text = mItem.Count.ToString();
      }
      else
      {
         mText.text = "";
      }
   }
}
