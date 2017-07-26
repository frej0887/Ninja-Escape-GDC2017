using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerSound : MonoBehaviour
{

    public AudioClip Walk;
    public AudioClip Jump;
    public AudioClip[] StickySound;

    public AudioSource Audio;

    public float WalkVolume;
    public float JumpVolume;
    public float StickyVolume;
    public float minWalkingPitch;
    public float maxWalkingPitch;

    public bool InSticky = false;
    public bool IsJumping = false;

    public void WalkSound()
    {

        if (!Audio.isPlaying)
        {
            if (!InSticky)
            {
                Audio.volume = WalkVolume;
                Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
                Audio.clip = Walk;
                Audio.Play();
            }
            else {
              
                int lyd = Random.Range(0, StickySound.Length);
                Audio.volume = StickyVolume;
                Audio.clip = StickySound[lyd];
                Audio.Play();
            }

        }
    }
    public void JumpSound()
    {

        
        Audio.volume = JumpVolume;
        Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
        Audio.clip = Jump;
        Audio.Play();

    }
    public void StopSound()
    {

        Audio.Stop();

    }

}
