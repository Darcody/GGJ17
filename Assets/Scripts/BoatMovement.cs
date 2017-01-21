using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] float maxTurningPerFrame = 10.0f;
    [SerializeField] float movementSpeed = 10.0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            Plane plane = new Plane(Vector3.up, transform.position);
            if (plane.Raycast(ray, out dist))
            {
                Quaternion rotation = Quaternion.LookRotation(ray.GetPoint(dist) - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxTurningPerFrame * Time.deltaTime);
            }
        }
        transform.Translate(new Vector3(0.0f, 0.0f, movementSpeed * Time.deltaTime));

    }
}
