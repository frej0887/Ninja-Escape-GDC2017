using UnityEngine;
using System.Collections;

public class SlipperyFloorScript : MonoBehaviour {
    public GameObject player;
    public float pushBackDistance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            print("SlipperyFloor");
               if(Vector3.Distance(transform.position, player.transform.position) > pushBackDistance ) {
                player.GetComponent<Pl>();
               }

        }

    }

    void OnTriggerExit() {


    }


}
