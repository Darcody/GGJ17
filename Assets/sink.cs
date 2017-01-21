using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sink : MonoBehaviour {
    public int speed = 10;
    public GameObject mesh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime/speed);
        if (mesh.transform.eulerAngles.x < 85) {
            mesh.transform.Rotate(Vector3.right * Time.deltaTime * 10, Space.World);
            //print(transform.eulerAngles.x);
        }
       
    }
}
