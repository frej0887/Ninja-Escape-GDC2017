using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    //Move
    public float moveSpeed;
    public float standardMoveSpeed = 5;
    public float rotationSpeed = 100;
    public int runSpeed = 8;

    //Crouch
    public int crouchSpeed = 2;
    public float normalHeight = 1.4f;
    public float crouchHeight = 0.4f;
    public CapsuleCollider myCapsuleCollider;
    public bool crouch = false;

    //Sticky and Slippery Floor
    public float stickyFloorSpeed;
    public bool onStickyFloor = false;
    public float slipperyFloorSpeed;
    public bool onSlippery = false;

    //Jump
    public float jumpHeight = 5;
    public float jumpTime = .9f;
    public float lastJump = -.9f;
    public bool isJumping =  false;

    //Stun
    public float addStunTime = 3f;
    public bool stun = false;
    public float time2;
    public float stunTime = 1;
    public TimerScript timer;
    public GameObject plusTimer;

    //Andet
    public PlayerSound PS;
    public Rigidbody myRigidBody;
    public Vector3 PlayerPos;
    public Vector3 PlayerSize;

    //Drunk controls
    public bool drunk = false;
    public bool flaskHit = false;
    public float drunkTimer;
    public float timeDrunk;
    public GameObject Flask;
    public GameObject Flask2;
    public GameObject Flask3;
    public GameObject Flask4;
    public GameObject Flask5;


    //Animation
    public Animator ninjaController;
    public float aniCrossFade;

    // Use this for initialization
    void Start ()    {
        myRigidBody = GetComponent<Rigidbody>();
        myCapsuleCollider = GetComponent<CapsuleCollider>();
        PS = GetComponent<PlayerSound>();
    }
	
	// Update is called once per frame
	void Update () {
        drunkTimer -= Time.deltaTime;
        if (Time.time - time2 >= stunTime)    {
            stun = false;
            plusTimer.SetActive(false);
        }/*
        if (ninjaController.GetBool("Jump") == true && transform.position.y)    {
            ninjaController.SetBool("Jump", false);
        }*/
    }

    void FixedUpdate() {
        if (onSlippery == false)    {
            Move();
        }
        Crouch();
        if (onStickyFloor == false)    {
            Jump();
        }
        Restart();
        Quit();
    }

    public void Move()    {
        if (stun == false && drunkTimer < 0)     {
            gameObject.layer = 8;
            transform.Translate(-moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0, moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);

            if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && isJumping == false) {
                PS.WalkSound();
                if (!crouch)    {
                    ninjaController.SetBool("Walk", true);
                    ninjaController.SetBool("Crouch", false);
                    ninjaController.SetBool("Idle", false);
                   // print("Move");
                }
                else if (crouch)    {
                    ninjaController.SetBool("Walk", true);
                    ninjaController.SetBool("Crouch", true);
                    //ninjaController.SetBool("Jump", false);
                    ninjaController.SetBool("Idle", false);
                }
            }
            else if ((Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) && isJumping == false)     {
                if (!crouch)    {
                    ninjaController.SetBool("Walk", false);
                    ninjaController.SetBool("Crouch", false);
                    ninjaController.SetBool("Idle", true);
                    //print("Still");
                }
                else if (crouch)    {
                    ninjaController.SetBool("Walk", false);
                    ninjaController.SetBool("Crouch", true);
                    //ninjaController.SetBool("Jump", false);
                    ninjaController.SetBool("Idle", false);
                }
            }

            if (Input.GetAxis("Horizontal") > 0)    {
                transform.eulerAngles = new Vector3(0,0,0);
            }
            else if (Input.GetAxis("Horizontal") < 0)    {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetAxis("Vertical") < 0)    {
                transform.eulerAngles = new Vector3(0, 90, 0);
            } 
            else if (Input.GetAxis("Vertical") > 0)    {
                transform.eulerAngles = new Vector3(0,-90, 0);
            }
        }
        else if (stun == false && drunkTimer >= 0)    {
            gameObject.layer = 8;
            transform.Translate(moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0, -moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);

            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)     {
                PS.WalkSound();
                if (!crouch)    {
                    ninjaController.SetBool("Walk", true);
                    ninjaController.SetBool("Crouch", false);
                    ninjaController.SetBool("Idle", false);
                }
                else if (crouch)    {
                    ninjaController.SetBool("Walk", true);
                    ninjaController.SetBool("Crouch", true);
                    //ninjaController.SetBool("Jump", false);
                    ninjaController.SetBool("Idle", false);
                }
            }
            else if ((Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) && isJumping == false)     {
                if (!crouch)     {
                    ninjaController.SetBool("Walk", false);
                    ninjaController.SetBool("Crouch", false);
                    ninjaController.SetBool("Idle", true);
                }
                else if (crouch)    {
                    ninjaController.SetBool("Walk", false);
                    ninjaController.SetBool("Crouch", true);
                    //ninjaController.SetBool("Jump", false);
                    ninjaController.SetBool("Idle", false);
                }
            }

            if (Input.GetAxis("Horizontal") < 0)    {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0)    {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetAxis("Vertical") > 0)     {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (Input.GetAxis("Vertical") < 0)     {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
    }
    
    public void Jump()    {
        if (stun == false && crouch == false)    {
            if (Time.time - lastJump > jumpTime) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpHeight, myRigidBody.velocity.z);
                    lastJump = Time.time;
                    PS.JumpSound();
                    PS.IsJumping = true;
                    isJumping = true;
                    ninjaController.SetBool("Walk", false);
                    ninjaController.SetBool("Crouch", false);
                    //ninjaController.SetBool("Jump", true);
                    ninjaController.SetBool("Idle", false);
                    ninjaController.Play("Jump");
                }
            }
            else {
                PS.IsJumping = false;
            }
        }
    }
    
    public void Crouch()    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.X))    {
            moveSpeed = crouchSpeed;
            myCapsuleCollider.height = crouchHeight;
            myCapsuleCollider.center = new Vector3(0, .28f, 0);
            ninjaController.Play("Crouch ned");
            crouch = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.X))    {
            moveSpeed = standardMoveSpeed;
            myCapsuleCollider.height = normalHeight;
            myCapsuleCollider.center = new Vector3(0, .7f, 0);
            crouch = false;
        }
    }

   /* public void Run() {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Z))    {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Z))     {
            moveSpeed = standardMoveSpeed;
        }
    }*/

    public void SlowDown()    {
        moveSpeed = stickyFloorSpeed;
        PS.InSticky = true;
    }

    public void normalPace()    {
        moveSpeed = standardMoveSpeed;
        PS.InSticky = false;
    }

    public void Restart() {
        if(Input.GetKeyDown(KeyCode.R)) {
            //SceneManager.LoadScene("Level2");
            transform.position = new Vector3(2.61f, 0.099f, -50.43f);
        }

    }

    public void Quit() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
    }
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

        if (other.gameObject.CompareTag("Barrel"))    {
            PS.BarrelHit();
            timer.AddTime(addStunTime);
            plusTimer.SetActive(true);
            stun = true;
            ninjaController.Play("Stun");
            time2 = Time.time;
            print("BARREL HIT");
            //ninjaController.CrossFade("Stun", aniCrossFade);
        }
        if(other.gameObject.CompareTag("SliderFloor")) {
            onSlippery = true;       
                
            myRigidBody.AddForce(0, 0, slipperyFloorSpeed * Time.deltaTime, ForceMode.Impulse);
            print("SlipperyFloor Activated");
     
        } 
        if (other.gameObject.CompareTag("Rome")) {
            drunkTimer = timeDrunk;
            flaskHit = true;
           // Destroy(Flask.gameObject);

           /* Destroy(Flask2.gameObject);
            Destroy(Flask3.gameObject);
            Destroy(Flask4.gameObject);
            Destroy(Flask5.gameObject);*/
         

            // print("FLASK IS HIT");
        }
       
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "StickyFloor") {
            onStickyFloor = false;
            normalPace();
        }
        if(other.tag == "SliderFloor") {
            onSlippery = false;
        }
    }

}

