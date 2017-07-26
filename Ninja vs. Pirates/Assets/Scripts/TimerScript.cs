using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    
    public Text timerTxt;
    public float currentTime;
    //public float extraTime;
    //bool addTimeSpg = false;
    //int counter = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CountUp();
    }
    /*
    void FixedUpdate() {
        if (addTimeSpg || (counter < 50000 && counter != 0)) {
            counter++;
            print(counter);
        }
    }*/

    public void CountUp() {/*
        if (addTimeSpg || (counter < 50000 && counter != 0))    {
            timerTxt.text = "Time: " + Mathf.Floor(currentTime * 10) / 10f + " +" + extraTime;
            addTimeSpg = false;
        }
        if (!addTimeSpg ^ (counter < 50000 && counter != 0))    {*/
            timerTxt.text = "Time: " + Mathf.Floor(currentTime * 10) / 10f;
           /* counter = 0;
        }*/
        currentTime += Time.deltaTime;

    }

    public void AddTime(float ekstraTime) {
        //this.extraTime = ekstraTime;
        //addTimeSpg = true;
        currentTime += ekstraTime;
    }
}
