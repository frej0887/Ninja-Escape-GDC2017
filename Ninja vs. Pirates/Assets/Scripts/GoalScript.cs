using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {
    public float badtime = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll) {
        if(coll.gameObject.CompareTag("Player")) {
            if (TimerScript.currentTime < badtime) {
                SceneManager.LoadScene("GoalScene");
            } else {
                SceneManager.LoadScene("BadNinja");

            }
        }
    }
}
