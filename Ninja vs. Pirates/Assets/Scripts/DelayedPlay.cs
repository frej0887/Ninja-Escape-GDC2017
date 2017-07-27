using UnityEngine;
using System.Collections;

public class DelayedPlay : MonoBehaviour
{

    public AudioSource Audio;

    public int i = 0;
    public int maxtime;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        i++;

        if (i > maxtime)
        {

            Audio.Play();

        }
    }
}
