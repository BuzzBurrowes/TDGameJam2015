using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
   public Transform LookAtObject;
    
   void Start() 
   {
	
   }
	
   void Update()
   {
	   Vector3 newPos = transform.position;
      newPos.x = LookAtObject.position.x;
      newPos.y = LookAtObject.position.y;
      transform.position = newPos;
   }
}
