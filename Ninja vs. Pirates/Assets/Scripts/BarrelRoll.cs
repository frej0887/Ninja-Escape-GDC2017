using UnityEngine;
using System.Collections;

public class BarrelRoll : MonoBehaviour {

    public Rigidbody myRigidBody;
    public int rotateSpeed;
    public int way = -1;
    public Renderer rend;
    public float rotateSpeed2;
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
        myRigidBody.AddForce(way * rotateSpeed * Time.deltaTime, 0, 0, ForceMode.Impulse);
       
        BS.RollSound();
    }

    void OnCollisionEnter(Collision coll) {
        if(coll.gameObject.CompareTag("EndBarrel")) {
            if (way == -1) {
                way = 1;
            }
            else if (way == 1) {
                way = -1;
            }
           
           // BS.BarrelTurn();

        }
    }

    void RotateTexture() {
        rend.material.mainTextureOffset += new Vector2(rotateSpeed2 * Time.deltaTime * myRigidBody.velocity.x, 0);
    }

}
