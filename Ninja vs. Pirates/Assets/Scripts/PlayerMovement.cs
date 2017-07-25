using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float standardMoveSpeed = 5;
    public float rotationSpeed = 100;
    public float jumpHeight = 5;
    public float jumpTime = .9f;
    public float lastJump = -.9f;
    public Rigidbody myRigidBody;
    public int runSpeed = 8;
    public int crouchSpeed = 2;
    public TimerScript timer;
    public bool stun = false;
    public float time2;
    public float stunTime = 1;
    public PlayerSound PS;
    public Vector3 PlayerPos;
    public Vector3 PlayerSize;
    public float stickyFloorSpeed;
    public bool onStickyFloor = false;

    // Use this for initialization
    void Start ()    {
        myRigidBody = GetComponent<Rigidbody>();
        PS = GetComponent<PlayerSound>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time2 >= stunTime)    {
            stun = false;
        }
    }

    void FixedUpdate()    {
        Move();
        //Crouch();
        Jump();
        //Run();
    }

    public void Move()    {
        //if (stun == false)    {
           // gameObject.layer = 8;
            if (Input.GetKey(KeyCode.D))    {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                print(moveSpeed);
                PS.WalkSound();
            }
            if (Input.GetKey(KeyCode.S))    {
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
                PS.WalkSound();
            }
            if (Input.GetKey(KeyCode.A))    {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                PS.WalkSound();
            }
            if (Input.GetKey(KeyCode.W))    {
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
                PS.WalkSound();
            }
        /*} else {
            gameObject.layer = 10;
        }*/
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
        if (stun == false)    {
            if (Time.time - lastJump > jumpTime)    {
                if (Input.GetKeyDown(KeyCode.Space))    {
                    myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpHeight, myRigidBody.velocity.z);
                    lastJump = Time.time;
                }
            }
        }
    }
    
    public void Crouch()    {
        if (Input.GetKeyDown(KeyCode.LeftControl))    {
            moveSpeed = crouchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))    {
            moveSpeed = standardMoveSpeed;
        }
    }

    public void Run() {
        if (Input.GetKeyDown(KeyCode.LeftShift))    {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))     {
            moveSpeed = standardMoveSpeed;
        }
    }
    
    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.CompareTag("Barrel")) {
            timer.AddTime(3f);
            stun = true;
            time2 = Time.time;
        }
    }

    public void SlowDown()    {
        moveSpeed = stickyFloorSpeed;
    }

    public void normalPace()    {
        moveSpeed = standardMoveSpeed;
    }

    public Vector3 getPlayerPos()    {
        PlayerPos = new Vector3(transform.position.x, transform.position.z, transform.position.y);
        return PlayerPos;
    }

    public Vector3 getPlayerSize()    {
        PlayerSize = new Vector3(transform.lossyScale.x, transform.lossyScale.z, transform.lossyScale.y);
        return PlayerSize;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "StickyFloor")    {
            onStickyFloor = true;
            SlowDown();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "StickyFloor") {
            onStickyFloor = false;
            normalPace();
        }
    }
}

