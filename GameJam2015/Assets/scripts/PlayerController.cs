using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour, ItemCollector
{
   public float VelocityScale = 1.0f;
   PlayableCharacter mPlayableCharacter = null;
   public PlayableCharacter Character
   {
      get { return mPlayableCharacter; }
      set { mPlayableCharacter = value; }
   }

   Rigidbody2D mRigidBody;
   Animator    mAnimator;

   void Start()
   {
	   mRigidBody = GetComponent<Rigidbody2D>();
      mAnimator = GetComponent<Animator>();   
	}
	
	void Update() 
   {
      float x = Input.GetAxis("Horizontal");
      float y = Input.GetAxis("Vertical");
      mRigidBody.velocity = new Vector2(x * VelocityScale, y * VelocityScale);
      if (mAnimator != null)
      {
         if (x < 0.5f && x > -0.5f && y < 0.5f && y > -0.5f)
            mAnimator.SetInteger("MovementState", 0);
         else if (x < -0.5f)
            mAnimator.SetInteger("MovementState", 4);
         else if (x > 0.5f)
            mAnimator.SetInteger("MovementState", 3);
         else if (y < -0.5f)
            mAnimator.SetInteger("MovementState", 1);
         else if (y > 0.5f)
            mAnimator.SetInteger("MovementState", 2);
      }
   }

   public bool TryToCollectItem(string itemType, Dictionary<string, string> props)
   {
      if (mPlayableCharacter == null)
         return false;
      return mPlayableCharacter.TryToCollectItem(itemType, props);
   }
}
