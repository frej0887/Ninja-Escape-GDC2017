using UnityEngine;
using System.Collections;

public class BarrelRoll : MonoBehaviour {

    public Rigidbody myRigidBody;
    public int moveSpeed;
    public int way = -1;
    public Renderer rend;
    public float rotateTextureSpeed;
    public BarrelSound BS;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody>(); 
        rend = GetComponent<Renderer>();
     //   BS = GetComponent<BarrelSound>();
    }
	
	// Update is called once per frame
	void Update () {
        RotateTexture();
	}

    void FixedUpdate() {
        Roll();
    }

    void Roll() {
        myRigidBody.AddForce(way * moveSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
       
        BS.RollSound();
    }

    void OnTriggerEnter(Collider coll) {
        //print("Collided with: ");
       // print(coll.gameObject.name);
        if(coll.gameObject.CompareTag("EndBarrel")) {
            myRigidBody.velocity = Vector3.zero;
            BS.BarrelTurn();
            if (way == -1) {
                way = 1;
            }
            else if (way == 1) {
                way = -1;
            }

        }
    }

    void RotateTexture() {
        rend.material.mainTextureOffset += new Vector2(rotateTextureSpeed * Time.deltaTime * myRigidBody.velocity.x, 0);
    }

}
