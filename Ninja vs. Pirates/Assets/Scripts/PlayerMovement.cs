using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5;
    public float rotationSpeed = 100;
    public float jumpHeight = 5;
    public float jumpTime = .9f;
    public float lastJump = -.9f;
    public Rigidbody myRigidBody;
    public int runSpeed = 8;
    public int crouchSpeed = 2;

	// Use this for initialization
	void Start ()    {
        myRigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()    {
        Move();
        Crouch();
        Jump();
        Run();
    }

    public void Move()    {
        if (Input.GetKey(KeyCode.D))    {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }
    }

    /*
    public void Turn()    {
        if (Input.GetKey(KeyCode.D))    {
            transform.Rotate(0,rotationSpeed*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))    {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }
    */
    
    public void Jump()    {
        if (Time.time - lastJump > jumpTime)    {
            if (Input.GetKeyDown(KeyCode.Space))    {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpHeight, myRigidBody.velocity.z);
                lastJump = Time.time;
            }
        }
    }

    public void Crouch()    {
        if (Input.GetKeyDown(KeyCode.LeftControl))    {
            moveSpeed = crouchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))    {
            moveSpeed = 5;
        }
    }

    public void Run() {
        if (Input.GetKeyDown(KeyCode.LeftShift))    {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))     {
            moveSpeed = 5;
        }
    }
}
