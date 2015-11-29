using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour 
{
   World theWorld;

   void Start() 
   {
	   theWorld = World.Instance;
      _SpawnLocalPlayer();
   }

   private void _SpawnLocalPlayer()
   {
      GameObject spawner = GameObject.Find("playerspawner");
      string prefabPath = "Assets/prefabs/Knight.prefab";
      UnityEngine.Object knightPrefab =
          UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
      if (knightPrefab != null)
      {
         GameObject spawnedInstance =
             (GameObject)GameObject.Instantiate(knightPrefab);
         spawnedInstance.name = knightPrefab.name;

         // Use the position of the spawner...
         //spawnInstance.transform.parent = spawner.gameObject.transform;
         Vector3 pos = spawner.gameObject.transform.position;
         spawnedInstance.transform.localPosition = pos;
         spawnedInstance.GetComponent<PlayerController>().Character = World.Instance.LocalPlayer;

         // tell the camera to watch the player...
         GameObject camera = GameObject.Find("Main Camera");
         camera.GetComponent<CameraController>().LookAtObject = spawnedInstance.transform;

         // now the player needs a menu...
         UnityEngine.Object menuPrefab =
            UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/prefabs/menus/Character-Menu-System.prefab", typeof(GameObject));
         GameObject characterMenu = (GameObject)GameObject.Instantiate(menuPrefab);
         CharacterMenuController menuController = characterMenu.GetComponent<CharacterMenuController>();
         menuController.Character = World.Instance.LocalPlayer;
         menuController.Show(false);
      }
   }

   void Update()
   {
	   // 
   }
}
