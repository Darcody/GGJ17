using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kompass : MonoBehaviour {

    public GameObject compassNeedle;
    public GameObject plate;
    public GameObject trackerPosition;
    Vector3 target=new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
       compassNeedle= GameObject.Find("Nadel");
       trackerPosition = GameObject.Find("Northpole");
        trackerPosition = GameObject.Find("Northpole");
    }
	
	// Update is called once per frame
	void Update () {
        float distanceToPlane = Vector3.Dot(compassNeedle.transform.up, trackerPosition.transform.position - compassNeedle.transform.position);
        Vector3 pointOnPlane = trackerPosition.transform.position - (compassNeedle.transform.up * distanceToPlane);
        compassNeedle.transform.LookAt(pointOnPlane, compassNeedle.transform.up);
    }
}
