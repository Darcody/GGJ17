using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    GameObject boat;
    Vector3 direction;

    void Start()
    {
        boat = GameObject.Find("Boat(Clone)");
        
        if (boat != null)
        {
            direction = CalculateDirection();

            boat.GetComponent<BoatMovement>().tornado = this.gameObject;
        }
    }

    void Update()
    {

        this.transform.Rotate(new Vector3(0.0f, 400.0f * Time.deltaTime, 0.0f));
        this.transform.position += direction * Time.deltaTime / 5.0f;
        if (this.transform.position.x > 2 || this.transform.position.z > 2 || this.transform.position.z < -2 || this.transform.position.x < -2)
        {
            Destroy(this.gameObject);
        }
    }

    Vector3 CalculateDirection()
    {
        Vector3 myDirection = boat.transform.position - this.transform.position;
        return myDirection.normalized;
    }
}
