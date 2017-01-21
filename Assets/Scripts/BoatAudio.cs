using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] allClips;
    AudioSource mySource;

    void Start()
    {
        mySource = GetComponent<AudioSource>();
        mySource.clip = allClips[0];
        mySource.loop = true;
        mySource.Play();

    }

    void Update()
    {
        
    }
}
