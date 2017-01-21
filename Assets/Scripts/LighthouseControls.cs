using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseControls : MonoBehaviour
{
    private GameObject m_lightTarget;
    private GameObject m_light;

    void Start()
    {
        m_lightTarget = transform.FindChild("LightHouseTarget").gameObject;
        m_light = transform.FindChild("Spotlight").gameObject;

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit ))
            {
                m_lightTarget.transform.position = hit.point;
            }
        }
    }
}
