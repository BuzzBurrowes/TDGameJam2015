using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
   Rigidbody2D mRigidBody;
   public float VelocityScale = 1.0f;
   void Start()
   {
	   mRigidBody = GetComponent<Rigidbody2D>();   
	}
	
	void Update() 
   {
      float x = Input.GetAxis("Horizontal");
      float y = Input.GetAxis("Vertical");
      mRigidBody.velocity = new Vector2(x * VelocityScale, y * VelocityScale);
	}
}
