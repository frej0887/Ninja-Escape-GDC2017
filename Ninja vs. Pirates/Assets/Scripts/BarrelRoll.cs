using UnityEngine;
using System.Collections;

public class BarrelRoll : MonoBehaviour {

    public Rigidbody myRigidBody;
    public int rotateSpeed;
    public int way = -1;
    public Renderer rend;
    public float rotateSpeed2;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody>(); 
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        RotateTexture();
	}

    void FixedUpdate() {
        Roll();
    }

    void Roll() {
        //transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);

        myRigidBody.AddForce(0, 0, way * rotateSpeed * Time.deltaTime, ForceMode.Impulse);
        //transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * way);
    }

    void OnCollisionEnter(Collision coll) {
        if(coll.gameObject.CompareTag("EndBarrel")) {
            if (way == -1) {
                way = 1;
            }
            else if (way == 1) {
                way = -1;
            }
        }
    }

    void RotateTexture() {
        rend.material.mainTextureOffset += new Vector2(rotateSpeed2 * Time.deltaTime * myRigidBody.velocity.z, 0);
    }

}
