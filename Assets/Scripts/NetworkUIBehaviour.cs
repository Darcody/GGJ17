using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUIBehaviour : MonoBehaviour
{

    public GameObject networkController;
    //public GameObject network;
    public InputField addressField;
    NetworkController manager; //= networkController.GetComponent<NetworkController>();

    public void Start()
    {
        networkController = GameObject.Find("NetworkManager");
        manager = networkController.GetComponent<NetworkController>();
    }
    public void onHostGameClicked()
    {
        //NetworkController manager = networkController.GetComponent<NetworkController>();
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
            Debug.Log("Server: port=" + manager.networkPort);
        }
        if (NetworkClient.active)
        {
            Debug.Log("Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
        }
    }

    public void onJoinGameClicked()
    {

        //NetworkController manager = networkController.GetComponent<NetworkController>();
        manager.StopClient();
        NetworkServer.Reset();
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.networkAddress = addressField.text;
            manager.StartClient();
            //manager.client.
            this.gameObject.SetActive(false);
        }
        if (NetworkServer.active)
        {
            Debug.Log("Server: port=" + manager.networkPort);
        }
        if (NetworkClient.active)
        {
            Debug.Log("Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
        }
    }

    public void onBackClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}
