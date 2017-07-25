using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerSound : MonoBehaviour {

    public AudioClip Walk;
    public AudioClip[] Jump;
    

    public AudioSource Audio;

    public float volume;
    public float minWalkingPitch;
    public float maxWalkingPitch;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void WalkSound()
    {
        if (!Audio.isPlaying)
        {
            volume = 0.2f;
            Audio.volume = volume;
            Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
            Audio.clip = Walk;
            Audio.Play();
        }
        }
    public void JumpSound() {
        volume = 1.0f;
        int lyd = Random.Range(0, Jump.Length);
        Audio.volume = volume;
        Audio.clip = Jump[lyd];
        Audio.Play ();
    }
    }
