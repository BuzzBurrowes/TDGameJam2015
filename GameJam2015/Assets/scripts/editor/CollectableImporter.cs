using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[Tiled2Unity.CustomTiledImporter]
class CustomImporterAddComponent : Tiled2Unity.ICustomTiledImporter
{
   public void HandleCustomProperties(UnityEngine.GameObject gameObject,
       IDictionary<string, string> props)
   {
      // Simply add a component to our GameObject
      if (props.ContainsKey("collectable"))
      {
         // Are we spawning an Appearing Block?
         if (props["collectable"] != "crate")
            return;

         // Load the prefab assest and Instantiate it
         string prefabPath = "Assets/prefabs/collectables/" + props["collectable"] + ".prefab";
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
            cc.ItemType = props["collectable"];
            foreach(string key in props.Keys)
               cc.Props[key] = props[key];
            Debug.Log("");
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