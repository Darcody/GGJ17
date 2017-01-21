using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseControls : MonoBehaviour
{
    [SerializeField] private float m_rotationSpeed = 5.0f;
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
                Vector3 direction = (m_lightTarget.transform.position - m_light.transform.transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                m_light.transform.rotation = Quaternion.Slerp(m_light.transform.transform.rotation, lookRotation, Time.deltaTime * m_rotationSpeed);
            }
        }
    }
}
