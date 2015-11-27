using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[Tiled2Unity.CustomTiledImporter]
class CollectableImporter : Tiled2Unity.ICustomTiledImporter
{
   public void HandleCustomProperties(UnityEngine.GameObject gameObject,
       IDictionary<string, string> props)
   {
      if (props.ContainsKey("itemtype"))
      {
         // Load the prefab assest and Instantiate it
         string prefabPath = "Assets/prefabs/collectables/" + props["itemtype"] + ".prefab";
         UnityEngine.Object spawn =
             UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
         if (spawn != null)
         {
            GameObject spawnInstance =
                (GameObject)GameObject.Instantiate(spawn);
            spawnInstance.name = spawn.name;

            // Use the position of the game object we're attached to
            spawnInstance.transform.parent = gameObject.transform;
            spawnInstance.transform.localPosition = Vector3.zero;

            CollectableController cc = spawnInstance.GetComponent<CollectableController>();
            cc.SetDescription(props);
         }
         else
         {
            EditorUtility.DisplayDialog("Promblem with Tiled file...",
                            "No prefab found at \"" + prefabPath + "\"", "Ooops");

         }
      }
   }

   public void CustomizePrefab(GameObject prefab)
   {
   }
}