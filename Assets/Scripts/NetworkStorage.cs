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

    bool clientBoatSpawned = false;
    bool clientTornadoSpawned = false;

    float timer = 0.0f;
    float randomAddition;
    int spawnBoatFirst;
    void Start()
    {
        randomAddition = Random.Range(1.0f, 3.0f);
        spawnBoatFirst = Random.Range(0,1);

    }
    void Update()
    {

        if (!isServer)
        {
            if (!clientBoatSpawned && spawnedBoat == true)
            {
                ghostBoat.SetActive(true);
                clientBoatSpawned = true;
            }
            if (!clientTornadoSpawned && spawnedTornado == true)
            {
                clientTornadoSpawned = true;
                tornado.SetActive(true);
            }
        }
        else
        {
            if (NetworkServer.connections.Count > 1)
            {
                if (!spawnedBoat || !spawnedTornado)
                {
                    if (timer > 6.0f + randomAddition)
                    {
                        if (!spawnedBoat && !spawnedTornado)
                        {
                            if (spawnBoatFirst == 1)
                            {
                                SpawnBoat();
                            }
                            else
                            {
                                SpawnTornado();
                            }
                            timer = 0.0f;
                        }
                        else if (!spawnedTornado)
                        {
                            SpawnTornado();
                        }
                        else if (!spawnedBoat)
                        {
                            SpawnBoat();
                        }

                    }
                    timer += Time.deltaTime;
                }
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
        tornado.transform.position = startPosition;
        spawnedTornado = true;
        tornado.SetActive(true);
    }
}
