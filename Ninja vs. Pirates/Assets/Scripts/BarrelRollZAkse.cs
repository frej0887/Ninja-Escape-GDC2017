using UnityEngine;
using System.Collections;

public class BarrelRollZAkse : MonoBehaviour {
    public Rigidbody myRigidBody;
    public int moveSpeed;
    public int way = -1;
    public Renderer rend;
    public float rotateSpeed;
   // public BarrelSound BS;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        //   BS = GetComponent<BarrelSound>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTexture();
    }

    void FixedUpdate()
    {
        Roll();
    }

    public void Roll()
    {
        myRigidBody.AddForce(0, 0, way * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        print("Is Rolling");

        //BS.RollSound();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("EndBarrel"))
        {
            if (way == -1)
            {
                print(way);
                way = 1;
            }
            else if (way == 1)
            {
                way = -1;
                print("Way is: " + way);
            }

            // BS.BarrelTurn();

        }
    }

    void RotateTexture()
    {
        rend.material.mainTextureOffset += new Vector2(rotateSpeed * Time.deltaTime * myRigidBody.velocity.z, 0);
    }

}
