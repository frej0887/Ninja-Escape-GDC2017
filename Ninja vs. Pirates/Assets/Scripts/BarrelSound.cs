using UnityEngine;
using System.Collections;

public class BarrelSound : MonoBehaviour {

    public AudioClip Barrelturn;
    public AudioClip BarrelRolling;

  
    public AudioSource Audio;
    public AudioSource Audio2;

    

    public float minPitch;
    public float maxPitch;

    public BarrelRoll BR;



    public void BarrelTurn() {
        
        Audio2.clip = Barrelturn;
        Audio2.Play();
        


    }  
    
    public void RollSound() {
       print("RollSound");

    
           if (!Audio.isPlaying) {
           // Debug.Log("Is AUdio PLaying");
         
            Audio.clip = BarrelRolling;
            Audio.pitch = Random.Range(minPitch, maxPitch);
            Audio.Play();
           
        }
    }

}


    
