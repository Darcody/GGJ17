using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFlash : MonoBehaviour {

    float timer = 5f;
    float flashDuration = 1f;
    public Light flashSource;
    public AudioClip[] list;
    AudioSource audio;
    private void Start()
    {
        
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if(timer <= 0f)
        {
            flashDuration = Random.value;
            timer = Random.value * 2.5f;
            //flashSource.intensity = Random.value;
            flashSource.enabled = true;
            if (!audio.isPlaying)
            {
                audio.clip = list[Random.Range(0, 5)];
                audio.Play();
            }

        }
        if(flashSource.enabled && flashDuration <= 0f)
        {
            flashSource.enabled = false;
        }
        if(!flashSource.enabled)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            float temp = Random.value;
            if(Mathf.Abs(flashSource.intensity - temp) < 0.1f)
            { 
                flashSource.intensity = Random.value;
            }
            flashDuration -= Time.deltaTime;
        }
	}
}
