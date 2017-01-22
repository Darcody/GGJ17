using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkController : NetworkManager {

    public Transform[] spawnPosition = new Transform[2];
    [Space(20)]
    public int playerRole;
    public bool debugablePlayerRole;
    private int curPlayer;

    public void Start()
    {
        spawnPosition[0] = GameObject.Find("SpawnLighthouse").transform;
        spawnPosition[1] = GameObject.Find("SpawnBoat").transform;
    }

    //Called on client when connect
    public override void OnClientConnect(NetworkConnection conn)
    {
        if(!debugablePlayerRole)
        { 
            curPlayer = GameManager.playerRole;
        }
        else
        {
            curPlayer = playerRole;
        }

        // Create message to set the player
        IntegerMessage msg = new IntegerMessage(curPlayer);

        // Call Add player and pass the message
        ClientScene.AddPlayer(conn, 0, msg);
    }

    // Server
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        spawnPosition[0] = GameObject.Find("SpawnLighthouse").transform;
        spawnPosition[1] = GameObject.Find("SpawnBoat").transform;

        // Read client message and receive index
        if (extraMessageReader.Length > 0)
        {
            var stream = extraMessageReader.ReadMessage<IntegerMessage>();
            curPlayer = stream.value;
        }
        //Select the prefab from the spawnable objects list
        var playerPrefab = spawnPrefabs[curPlayer];

        // Create player object with prefab
        var player = Instantiate(playerPrefab, spawnPosition[curPlayer].position, spawnPosition[curPlayer].rotation) as GameObject;

        // Add player object for connection
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public void OnApplicationQuit()
    {
        if (Network.isClient)
        {
            //NetworkServer.DisconnectAll();
            StopClient();
        }

        if (Network.isServer)
        {
            //NetworkServer.Shutdown();
            Debug.Log("This is a Server");
            StopHost();
        }
    }
}

