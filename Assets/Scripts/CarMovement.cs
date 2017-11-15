using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public float CurrentSpeed = 0f;
    public float MaxSpeedUp = 20f;
    public float MaxSpeedDown = -5f;
    public float AccelarationUp = 0.1f;
    public float AccelarationDown = 0.1f;
    public float Deceleration = 0.05f;
    private Vector3 Velocity = Vector3.zero;
    //rotation related
    public float AccelerationRotation = 3f;

    // Use this for initialization
    void Start () {
        Debug.Log("Coucou Start!");
    }

	// Update is called once per frame
	void Update () {

		HandleMovement ();
		HandleRotation ();

    }   

	private void HandleRotation()
	{
		Quaternion newRotation = transform.rotation;

		bool IsQKeyDown = Input.GetKey(KeyCode.Q);
		bool IsDKeyDown = Input.GetKey(KeyCode.D);

		//Turn the Object
		if (IsQKeyDown)
		{
			newRotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - AccelerationRotation, transform.rotation.eulerAngles.z));

		}

		else if (IsDKeyDown)
		{
			newRotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + AccelerationRotation, transform.rotation.eulerAngles.z));
		}

		//print the rotation to the object
		transform.rotation = newRotation;
	}

	private void HandleMovement()
	{
		bool IsZKeyDown = Input.GetKey(KeyCode.Z);
		bool IsSKeyDown = Input.GetKey(KeyCode.S);


		//Add speed to the object
		if (IsZKeyDown)
		{
			if(CurrentSpeed < MaxSpeedUp)
			{ 
				CurrentSpeed += AccelarationUp;
				Debug.Log(CurrentSpeed);

			}
		}
		//Remove Speed to the object
		else if (IsSKeyDown)
		{
			if (CurrentSpeed > MaxSpeedDown)
			{
				CurrentSpeed -= AccelarationDown;
				Debug.Log(CurrentSpeed);

			}
		}
		//Deceleration of the car
		//else if (IsZKeyDown == false && IsSKeyDown == false)
		else if (!IsZKeyDown && !IsSKeyDown)
		{
			if (Mathf.Abs(CurrentSpeed) > 0.1f)
			{
				// Make Speed tends to 0
				if (CurrentSpeed < 0f)
				{
					CurrentSpeed += Deceleration;
				}
				else if (CurrentSpeed > 0f)
				{
					CurrentSpeed -= Deceleration;
				}
			}
			else
			{
				CurrentSpeed = 0f;
			}
		}

		//change the Velocity of the Object 
		//Add some new information to adapt the speed to the rotation of the object
		Velocity = transform.forward * CurrentSpeed;

		//link the speed to the clock of the computer to make sure the movement of the object is constant
		transform.position += Time.deltaTime * Velocity;
	}
}
