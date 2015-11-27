using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[Tiled2Unity.CustomTiledImporter]
class SpawnerImporter : Tiled2Unity.ICustomTiledImporter
{
   public void HandleCustomProperties(UnityEngine.GameObject gameObject,
       IDictionary<string, string> props)
   {
      // Simply add a component to our GameObject
      if (props.ContainsKey("type") && props["type"] == "spawner")
      {
         string prefabPath = "Assets/prefabs/playerspawner.prefab";
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
         }
         else
         {
            EditorUtility.DisplayDialog("Promblem with Tiled file...",
                            "No spawner playerspawner.prefab found", "Ooops");

         }
      }
   }

   public void CustomizePrefab(GameObject prefab)
   {
   }
}