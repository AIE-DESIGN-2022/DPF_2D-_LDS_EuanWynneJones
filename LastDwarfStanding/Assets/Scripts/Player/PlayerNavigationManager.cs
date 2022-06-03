using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Declaring this class PlayerController
public class PlayerNavigationManager : MonoBehaviour
{
	public bool isControllerActive = true;	
	public float moveSpeed = 6.0F;

	//private bool IsGrounded = true;
	void Start()
	{

	}

	void Update()

	{
		if (!isControllerActive) return;
       
		float horiMove = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		transform.Translate(Vector3.right * horiMove);

	}


	void OnCollisionStay(Collision collisionInfo)
	{
		//IsGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{

		//IsGrounded = false;
	}


}