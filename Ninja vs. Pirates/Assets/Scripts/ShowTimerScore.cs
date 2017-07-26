using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTimerScore : MonoBehaviour {
    public TimerScript showTimer;
    public Text timerScore;
	// Use this for initialization
	void Start () {
        timerScore.text = "Your Time: " + showTimer.currentTime;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
