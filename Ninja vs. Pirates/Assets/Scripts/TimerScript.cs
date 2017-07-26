using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    
    public Text timerTxt;
    public float currentTime;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CountUp();

    }

    public void CountUp() {
        timerTxt.text = "Time: " + Mathf.Floor(currentTime*10)/10f;
        currentTime += Time.deltaTime;
    }



    public void AddTime(float ekstraTime) {
        currentTime += ekstraTime;
    }
}
