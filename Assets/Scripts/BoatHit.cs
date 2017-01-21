using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHit : MonoBehaviour {
    public GameObject toSink;
    public GameObject sinking;

    bool sunk = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain") {
            // Destroy(this);
            if (sunk == false) {
                print("Lose");
                Instantiate(sinking, this.transform.position, this.transform.rotation);
                GetComponent<BoatMovement>().enabled = false;
                Destroy(toSink.gameObject);
                sunk = true;
            }
          
        }

        if(collision.gameObject.tag == "Harbour")
        {
            print("Win");
            GetComponent<BoatMovement>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harbour")
        {
            print("Win");
            GetComponent<BoatMovement>().enabled = false;
        }
    }
}
