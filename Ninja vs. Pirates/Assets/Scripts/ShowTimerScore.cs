using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowTimerScore : MonoBehaviour {
    public Text timerScore;
   
    // Use this for initialization
    void Start () {
        
        timerScore.text = "Your Time: " + TimerScript.currentTime.ToString("N2");
       
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
