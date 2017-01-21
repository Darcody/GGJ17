using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LighthouseLightMovement : NetworkBehaviour {
    [SerializeField] private float m_rotationSpeed = 5.0f;
    private GameObject m_lightTarget;
    private GameObject m_light;

    void Start()
    {
        m_lightTarget = transform.FindChild("LightHouseTarget").gameObject;
        m_light = transform.FindChild("Spotlight").gameObject;

    }

    // Update is called once per frame
    void Update () {
        Vector3 direction = (m_lightTarget.transform.position - m_light.transform.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        m_light.transform.rotation = Quaternion.Slerp(m_light.transform.transform.rotation, lookRotation, Time.deltaTime * m_rotationSpeed);
    }
}
