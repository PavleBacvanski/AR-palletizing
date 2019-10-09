using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip box;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        //clip = GetComponent<AudioClip>();
        //source = GetComponent<AudioSource>();
        //source.clip = clip;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        source.Play();
    }
   
}
