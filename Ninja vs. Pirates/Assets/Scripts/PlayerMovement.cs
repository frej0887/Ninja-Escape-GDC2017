using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5;
    public float rotationSpeed = 100;
    Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()    {
        Move();
        Turn();
    }

    public void Move()    {
        if (Input.GetKey(KeyCode.W))    {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, - moveSpeed * Time.deltaTime);
        }
    }

    public void Turn()    {
        if (Input.GetKey(KeyCode.D))    {
            transform.Rotate(0,rotationSpeed*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))    {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void Jump()    {
        if (Input.GetKey(KeyCode.Space))    {
            
        }
    }

    public void Crouch()    {
        if (Input.GetKeyDown(KeyCode.LeftControl))    {
            moveSpeed = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))    {
            moveSpeed = 5;
        }
    }
}
