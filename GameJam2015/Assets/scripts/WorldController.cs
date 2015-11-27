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
      UnityEngine.Object spawn =
          UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
      if (spawn != null)
      {
         GameObject spawnInstance =
             (GameObject)GameObject.Instantiate(spawn);
         spawnInstance.name = spawn.name;

         // Use the position of the spawner...
         //spawnInstance.transform.parent = spawner.gameObject.transform;
         Vector3 pos = spawner.gameObject.transform.position;
         spawnInstance.transform.localPosition = pos;
         spawnInstance.GetComponent<PlayerController>().Character = World.Instance.LocalPlayer;

         // tell the camera to watch the player...
         GameObject camera = GameObject.Find("Main Camera");
         camera.GetComponent<CameraController>().LookAtObject = spawnInstance.transform;
      }
   }

   void Update()
   {
	   
   }
}
