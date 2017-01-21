using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUIBehaviour : MonoBehaviour {

    public GameObject networkController;
    //public GameObject network;
    public InputField addressField;

    public void Start()
    {
        networkController = GameObject.Find("NetworkManager");
    }
    public void onHostGameClicked()
    {
        NetworkController manager = networkController.GetComponent<NetworkController>();
        /*if(networkController == null)
        {
            Instantiate(network, Vector3.zero, Quaternion.identity);
            networkController = GameObject.Find("NetworkManager(Clone)");
        }
        else
        {
            Destroy(networkController);
            Instantiate(network, Vector3.zero, Quaternion.identity);
            networkController = GameObject.Find("NetworkManager(Clone)");
        }*/
        /*if (NetworkClient.active)
        {
            //Network.CloseConnection(Network.connections[0], true);
            //manager.StopClient();
            Network.Disconnect();
        }
        if (NetworkServer.active)
        {
            //NetworkServer.DisconnectAll();
            //NetworkServer.Shutdown();
            //manager.StopHost();
            Network.Disconnect();
        }*/

        //manager.StopClient();
        manager.StopHost();
        
        //Network.Disconnect();
        //MasterServer.UnregisterHost();
        
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            NetworkServer.Reset();
            manager.StartHost();
            this.gameObject.SetActive(false);
        }
        if (NetworkServer.active)
        {
            Debug.Log("Server: port=" + networkController.GetComponent<NetworkController>().networkPort);
        }
        if (NetworkClient.active)
        {
            Debug.Log("Client: address=" + networkController.GetComponent<NetworkController>().networkAddress + " port=" + networkController.GetComponent<NetworkController>().networkPort);
        }
    }

    public void onJoinGameClicked()
    {
        if (Network.isClient)
        {
            //Network.CloseConnection(Network.connections[0], true);
            networkController.GetComponent<NetworkController>().StopClient();
        }
        if (Network.isServer)
        {
            //NetworkServer.Shutdown();
            networkController.GetComponent<NetworkController>().StopHost();
        }
        NetworkController manager = networkController.GetComponent<NetworkController>();
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.networkAddress = addressField.text;
            manager.StartClient();
            this.gameObject.SetActive(false);
        }
        if (NetworkServer.active)
        {
            Debug.Log("Server: port=" + networkController.GetComponent<NetworkController>().networkPort);
        }
        if (NetworkClient.active)
        {
            Debug.Log("Client: address=" + networkController.GetComponent<NetworkController>().networkAddress + " port=" + networkController.GetComponent<NetworkController>().networkPort);
        }
    }

    public void Update()
    {
       
        /*if (NetworkClient.active && !ClientScene.ready)
        {
            
                ClientScene.Ready(networkController.GetComponent<NetworkController>().client.connection);

                if (ClientScene.localPlayers.Count == 0)
                {
                    ClientScene.AddPlayer(0);
                }
            }*/
        }
    

    public void onBackClicked()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnApplicationQuit()
    {
        if (Network.isClient)
        {
            //NetworkServer.DisconnectAll();
            networkController.GetComponent<NetworkController>().StopClient();
        }
        if(Network.isServer)
        {
            NetworkServer.Shutdown();
            networkController.GetComponent<NetworkController>().StopHost();
        }
        
        
    }
}
