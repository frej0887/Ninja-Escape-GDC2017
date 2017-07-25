using UnityEngine;
using System.Collections;

public class BarrelSound : MonoBehaviour {

    public AudioClip Barrelturn;
    public AudioClip BarrelRolling;

  
    public AudioSource Audio;

    public float volume = 0.2f;

    public float minPitch;
    public float maxPitch;

    public BarrelRoll BR;

    void Start() {

        Audio.volume = volume;

    }

   /* public void BarrelTurn() {
        Audio.stop();
        Audio.clip = Barrelturn;
        Audio.Play();


    } */ 
    
    


    public void RollSound() {
        //print("RollSound");

    
           if (!Audio.isPlaying) { 
           // Debug.Log("Is AUdio PLaying");
            Audio.clip = BarrelRolling;
            Audio.pitch = Random.Range(minPitch, maxPitch);
            Audio.Play();
           
        }
    }
   
    }

