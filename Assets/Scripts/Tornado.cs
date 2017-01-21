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
        int side = Random.Range(0, 3);
        Vector3 startPosition;
        float randomPos = Random.Range(-1.0f, 1.0f);
        switch (side)
        {
            case 0:
                startPosition = new Vector3(-1, 0.0f, randomPos);
                break;
            case 1:
                startPosition = new Vector3(1, 0.0f, randomPos);
                break;
            case 2:
                startPosition = new Vector3(randomPos, 0.0f, -1);
                break;
            case 3:
                startPosition = new Vector3(randomPos, 0.0f, 1);
                break;
            default:
                startPosition = new Vector3(-1, 0.0f, -1);
                break;
        }
        this.transform.position = startPosition;
        if (boat != null)
        {
            direction = CalculateDirection();
        }
    }

    void Update()
    {

        this.transform.Rotate(new Vector3(0.0f, 400.0f * Time.deltaTime, 0.0f));
        this.transform.position += direction * Time.deltaTime / 5.0f;
        if (boat != null)
        {
            float dist = Vector3.Distance(this.transform.position, boat.transform.position);
            if (dist < 1.5f)
            {
                Vector3 pullDirection = this.transform.position - boat.transform.position;
                boat.transform.position += pullDirection.normalized * (Time.deltaTime * (1.5f - dist)) / 50;

            }
        }
        else
        {
            boat = GameObject.Find("Boat(Clone)");
            direction = CalculateDirection();
        }
        if (this.transform.position.x > 2 || this.transform.position.z > 2)
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
