using UnityEngine;
using System.Collections;

public class DelayedPlay1 : MonoBehaviour    {

    public AudioSource Audio;

    public int number_i = 0;
    public int maxtime = 0;
    // Use this for initialization
    void Start()    {

    }

    // Update is called once per frame
    void Update()    {
        number_i++;

        if (number_i > maxtime)
        {

            Audio.Play();

        }
    }
}
