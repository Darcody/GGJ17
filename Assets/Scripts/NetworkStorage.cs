using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStorage : NetworkBehaviour
{
    [SyncVar] bool spawnedBoat = false;
    [SyncVar] bool spawnedTornado = false;

    [SerializeField] GameObject ghostBoat;
    [SerializeField] GameObject tornado;

    float timer = 0.0f;
    void Update()
    {
        
        if(!isServer)
        {
            if(spawnedBoat == true)
            {
                ghostBoat.SetActive(true);
            }
            if(spawnedTornado == true)
            {
                tornado.SetActive(true);
            }
        } else
        {
            Debug.Log(Network.connections.Length);
            if (!spawnedBoat)
            {
                if (timer > 6.0f)
                {
                    SpawnBoat();
                    timer = 0.0f;
                }
                timer += Time.deltaTime;
            }
        }
    }

    public void SpawnBoat()
    {
        spawnedBoat = true;
        ghostBoat.SetActive(true);
    }
    public void SpawnTornado()
    {
        spawnedTornado = true;
        tornado.SetActive(true);
    }
}
