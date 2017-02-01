using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoatMovement : NetworkBehaviour
{
    [SerializeField] float maxTurningPerFrame = 10.0f;
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] GameObject boatCam;

    private bool readyForAction = false;
    public GameObject compass;
    public GameObject tornado;
    public GameObject rainPS;
    void Start()
    {
        if (isLocalPlayer)
        {
            GameObject.Find("LighthouseCamera").SetActive(false);
            
            return;
        } else
        {
            boatCam.SetActive(false);
            if (compass != null) {
                compass.SetActive(false);
                rainPS.SetActive(false);
            }
        }
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if(!readyForAction)
            { 
                readyForAction = true;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            Plane plane = new Plane(Vector3.up, transform.position);
            if (plane.Raycast(ray, out dist))
            {
                Quaternion rotation = Quaternion.LookRotation(ray.GetPoint(dist) - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxTurningPerFrame * Time.deltaTime);
            }
        }
        if(readyForAction)
        { 
            transform.Translate(new Vector3(0.0f, 0.0f, movementSpeed * Time.deltaTime));
            if(tornado != null)
            {
                float dist = Vector3.Distance(tornado.transform.position, this.transform.position);
                if (dist < 1.5f)
                {
                    Vector3 pullDirection = tornado.transform.position - this.transform.position;
                    this.transform.position -= pullDirection.normalized * (Time.deltaTime * (1.5f - dist)) / 50;

                }
            }
        }
    }
}
