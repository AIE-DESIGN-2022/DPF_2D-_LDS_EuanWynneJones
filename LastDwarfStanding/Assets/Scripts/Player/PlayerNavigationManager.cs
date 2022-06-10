using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Declaring this class PlayerController
public class PlayerNavigationManager : MonoBehaviour
{
	public bool isControllerActive = true;
	public float moveSpeed = 6.0F;
	public bool _FacingRight = true;
	public Transform playerObject;
	public float lastMove;
	Rigidbody rb;

	//private bool IsGrounded = true;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()

	{
		if (!isControllerActive) return;

		float horiMove = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		rb.AddForce(new Vector3(horiMove, 0,0), ForceMode.VelocityChange);
		//transform.Translate(Vector3.right * horiMove);
		
       
		if (horiMove != lastMove)
		{
			HoriMove(horiMove);

		}
		lastMove = horiMove;

	}


	void OnCollisionStay(Collision collisionInfo)
	{
		//IsGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{

		//IsGrounded = false;
	}

	public void HoriMove(float horiMove)
	{
		if (horiMove > 0 && !_FacingRight)
		{
			// ... flip the player.
			//Debug.Log("Flipped Left");
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (horiMove < 0 && _FacingRight)
		{
			// ... flip the player.
			//Debug.Log("Flipped Right");
			Flip();
		}
	}
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_FacingRight = !_FacingRight;

		// Multiply the player's x local scale by -1.
		/*Vector3 theScale  = transform.localScale;
		theScale.x *= -1;
		transform.localScale = new Vector3 (theScale.x, transform.localScale.y, transform.localScale.z);*/
		if (!_FacingRight)
		{
			playerObject.rotation = new Quaternion(0, 180, 0, 0);
		}
		else if (_FacingRight)
		{
			playerObject.rotation = new Quaternion(0, 0, 0, 0);

		}

	}


}




