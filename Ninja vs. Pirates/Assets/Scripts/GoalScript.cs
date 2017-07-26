using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll) {
        if(coll.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene("GoalScene");

        }
    }
}
