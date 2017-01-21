using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LighthouseControls : NetworkBehaviour
{
    [SerializeField] Camera lighthouseCam;
    void Start()
    {
        GameObject.Find("Lighthouse").GetComponent<LighthouseLightMovement>().m_lightTarget = this.gameObject;
        if (!isLocalPlayer)
        {
            return;
        }
        
        lighthouseCam = GameObject.Find("LighthouseCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Ray mouseRay = lighthouseCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit ))
            {
                this.transform.position = hit.point;
            }
        }
    }
}
