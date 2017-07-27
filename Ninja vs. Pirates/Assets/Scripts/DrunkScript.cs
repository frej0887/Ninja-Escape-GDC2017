using UnityEngine;
using System.Collections;

public class DrunkScript : MonoBehaviour {
    public Animator flask;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //flask.Play("Fall");
            print("Yo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

}
