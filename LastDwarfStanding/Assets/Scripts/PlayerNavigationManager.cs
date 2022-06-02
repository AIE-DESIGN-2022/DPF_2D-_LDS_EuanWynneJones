using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Declaring this class PlayerController
public class PlayerNavigationManager : MonoBehaviour
{

	//declared public variables, because its public, these variables can be altered in the Inspector panel of the GameObject that has this script added as a component
	public float moveSpeed = 6.0F;

	//this is a private bool (either true or false) variable. Since it is private, it can only be accessed within this class.
	private bool IsGrounded = true;
	//Start function gets called when the object this script lies in is first created
	void Start()
	{

	}

	//Update function gets called every frame of the game. Usually there are 50 frames per second
	void Update()
	{

		//Calculating the amount of movement vertically and horizontally and assigning it to a float value (vertMove and horiMove)
		//Inputs "Vertical" and "Horizontal" are mapped to specific keys defined in Unitys Edit->ProjectSettings->Input
		float horiMove = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

		//Here we are moving the character based on the float values calculated above
		//We get the transform of the GameObject that this script is in. We then Translate (Move) it in the vector direction multiplied by the float value calculated
		transform.Translate(Vector3.right * horiMove);

		//We check if the "Jump" input has been pushed.
	}

	//This function is called once per frame for every collider/rigidbody that is touching the rigidbody/collider
	void OnCollisionStay(Collision collisionInfo)
	{
		//So when your character is touching something (most likely the ground) you can jump as isGrounded is set to true
		IsGrounded = true;
	}

	//this function is called when the collider/rigidbody has stopped touching another rigidbody/collider
	void OnCollisionExit(Collision collisionInfo)
	{
		//when your character stops touching something, set IsGrounded to false, as they are in the air and can't jump
		IsGrounded = false;
	}


}