using UnityEngine;
using System.Collections;

public class StickyFloorScript : MonoBehaviour {
    public float stickyFloorSpeed;
    public bool stickyWalk = false;
    public PlayerMovement plMove;
    public Vector2 QuadPos;
    public Vector2 QuadSize;
    public Vector2 PlayerPos;
    public Vector2 PlayerSize;

    // Use this for initialization
    void Start ()    {
        //plMove = GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {
        StickyFloors();
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

    void StickyFloors() {
        QuadPos = new Vector2(transform.position.x, transform.position.z);
        QuadSize = new Vector2(transform.lossyScale.x, transform.lossyScale.z);
        PlayerPos = new Vector2(plMove.transform.position.x, plMove.transform.position.z);
        if (QuadPos[0] - QuadSize[0]/2 < PlayerPos[0] && PlayerPos[0] < QuadPos[0] + QuadSize[0] / 2 && QuadPos[1] - QuadSize[1] / 2 < PlayerPos[1] && PlayerPos[1] < QuadPos[1] + QuadSize[1] / 2) {
            print("Test");
            plMove.moveSpeed = stickyFloorSpeed;
        }
        else {
            plMove.moveSpeed = plMove.standardMoveSpeed;
        }

    }

}
