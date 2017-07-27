using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerSound : MonoBehaviour
{

    public AudioClip Walk;
    public AudioClip Jump;
    public AudioClip[] StickySound;
    public AudioClip[] BarrelHitSound;
    public AudioClip[] StartDrunkSound;
    public AudioClip[] BubblesSound;
    public AudioClip Burp;

    public AudioSource Audio;
    public AudioSource AudioSource2;

    public float WalkVolume;
    public float JumpVolume;
    public float StickyVolume;
    public float BarrelHitVolume;
    public float minWalkingPitch;
    public float maxWalkingPitch;
    public float BubblesVolume;
    public float DrunkStartVolume;
    public float BurpVolume;

    public bool HasPlayedStartSound = false;
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
    public void BarrelHit() {

        Audio.volume = BarrelHitVolume;
        Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
        int lyd = Random.Range(0, BarrelHitSound.Length);
        Audio.clip = BarrelHitSound[lyd];
        Audio.Play();

    }
    public void DrunkWalkSound() {
        WalkSound();
        AudioSource2.volume = BarrelHitVolume;
        AudioSource2.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
        int lyd = Random.Range(0, BubblesSound.Length);
        AudioSource2.clip = BubblesSound[lyd];
        AudioSource2.Play();
    }
    public void StartDrunk()
    {
        Audio.volume = DrunkStartVolume;
        Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
        int lyd = Random.Range(0, StartDrunkSound.Length);
        Audio.clip = StartDrunkSound[lyd];
        Audio.Play();
        HasPlayedStartSound = true;


    }
    public void EndDrunk() {
        Audio.volume = BurpVolume;
        Audio.pitch = Random.Range(minWalkingPitch, maxWalkingPitch);
        Audio.clip = Burp;
        Audio.Play();
        HasPlayedStartSound = false;
    }

}
