using UnityEngine;
using System.Collections;

public class StickyFloorScript : MonoBehaviour {
    public float stickyFloorSpeed;
    public bool stickyWalk = false;
    public PlayerMovement plMove;

    // Use this for initialization
    void Start ()    {
        plMove = GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnColliderEnter(Collision coll)
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
    }
}
