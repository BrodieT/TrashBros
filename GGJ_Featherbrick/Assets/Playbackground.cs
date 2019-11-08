using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playbackground : MonoBehaviour
{

    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        if (GLOBAL_.MusicEnabled)
        {
            this.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
