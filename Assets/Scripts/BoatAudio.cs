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

    public void Crash()
    {
        mySource.clip = allClips[1];
        mySource.loop = false;
        mySource.Play();
    }
}
