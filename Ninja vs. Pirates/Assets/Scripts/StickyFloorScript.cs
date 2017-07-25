using UnityEngine;
using System.Collections;

public class StickyFloorScript : MonoBehaviour {
    public float stickyFloorSpeed;
    public PlayerMovement player;
    public Vector3 QuadPos;
    public Vector3 QuadSize;
    public Vector3 PlayerPos;
    public Vector3 PlayerSize;

    public Rigidbody myRigidBody;

    // Use this for initialization
    void Start ()    {
        //player = GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {
        //StickyFloors();
    }

    /*
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            stickyWalk = true;
            plMove.moveSpeed = stickyFloorSpeed;
        }
        else
        {
            stickyWalk = false;
            plMove.moveSpeed = plMove.standardMoveSpeed;
        }
    }*/

    /*
    void StickyFloors() {
        QuadPos = getQuadPos();
        QuadSize = getQuadSize();
        PlayerPos = player.getPlayerPos(); 
        PlayerSize = player.getPlayerSize(); 
        if (QuadPos[0] - QuadSize[0]/2 < PlayerPos[0] + PlayerSize[0]/2 &&
            QuadPos[0] + QuadSize[0]/2 > PlayerPos[0] - PlayerSize[0]/2 &&
            QuadPos[1] - QuadSize[1]/2 < PlayerPos[1] + PlayerSize[1]/2 &&
            QuadPos[1] + QuadSize[1]/2 > PlayerPos[1] - PlayerSize[1]/2 &&
            QuadPos[2] + .5 + PlayerPos[2]/2 > PlayerPos[2]) {
            print("Slow");
            SlowDown();
        }
        else {
            normalPace();
            print("Normal");    
        }
    }

    void SlowDown() {
        player.SlowDown();
    }

    void normalPace() {
        player.normalPace();
    }

    public Vector3 getQuadPos()    {
        QuadPos = new Vector3(transform.position.x, transform.position.z, transform.position.y);
        return QuadPos;
    }

    public Vector3 getQuadSize()    {
        QuadSize = new Vector3(transform.lossyScale.x, transform.lossyScale.z, transform.lossyScale.y);
        return QuadSize;
    }*/
}
