using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostship : MonoBehaviour {

    public GameObject player;
    public GameObject light;
    public float speed = 10f;
    public float dist = 0.5f;
    bool active = true;
    bool stunned = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Boat(Clone)");
        light = GameObject.Find("LighthouseTarget(Clone)");
        if (light != null) {
            if (Vector3.Distance(light.transform.position, transform.position) < dist)
            {
                stunned = true;
            }
            else { stunned = false; }
        }
     
        

        if (active)
        {
            if (!stunned)
            {
                if (player != null)
                {

                    transform.position = Vector3.Lerp(transform.position, player.transform.position, speed);
                    transform.LookAt(player.transform.position);
                }
            }
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        active = false;
    }
}
