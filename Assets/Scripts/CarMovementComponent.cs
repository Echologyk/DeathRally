using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementComponent : MonoBehaviour {

    float CurrentSpeed = 0f;

    public float MaxSpeed = 5f;

	// Use this for initialization
	void Start ()
    {
        CurrentSpeed = MaxSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentSpeed > 0f)
        {
            Vector3 Velocity = new Vector3(0, 0, CurrentSpeed);
            transform.position += Velocity;
        }
	}

    public float GetCurrentSpeed()
    {
        return CurrentSpeed;
    }
}
