using UnityEngine;
using System.Collections;

public class DrunkScript : MonoBehaviour {
   // public Animator flask;
    public PlayerMovement plMove;
    public GameObject Drunk;

	// Use this for initialization
	void Start () { 
        
}
	
	// Update is called once per frame
	void Update () {
        IsDrunkAni();
	}

    public void IsDrunkAni() {
        if(plMove.flaskHit == true) {
            //flask.Play("Fall");
            print("Yo!!");
            this.enabled = false;
            Destroy(Drunk.gameObject);
        }

    }


    }

    /*public void onTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //flask.Play("Fall");
            print("Yo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }*/

