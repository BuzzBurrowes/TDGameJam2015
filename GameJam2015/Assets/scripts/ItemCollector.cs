using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ItemCollector 
{
   bool TryToCollectItem(string itemType, Dictionary<string, string> props);
}
