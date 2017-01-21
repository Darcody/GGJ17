using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUIBehaviour : MonoBehaviour {

    public GameObject networkController;
    public InputField addressField;

    public void onHostGameClicked()
    {
        NetworkController manager = networkController.GetComponent<NetworkController>();
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.StartHost();
            this.gameObject.SetActive(false);
        }
    }

    public void onJoinGameClicked()
    {

        NetworkController manager = networkController.GetComponent<NetworkController>();
        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            manager.networkAddress = addressField.text;
            manager.StartClient();
            this.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (NetworkServer.active)
        {
          Debug.Log("Server: port=" + networkController.GetComponent<NetworkController>().networkPort);
        }
        if (NetworkClient.active)
        {
            Debug.Log( "Client: address=" + networkController.GetComponent<NetworkController>().networkAddress + " port=" + networkController.GetComponent<NetworkController>().networkPort);
        }

        if (NetworkClient.active && !ClientScene.ready)
        {
            
                ClientScene.Ready(networkController.GetComponent<NetworkController>().client.connection);

                if (ClientScene.localPlayers.Count == 0)
                {
                    ClientScene.AddPlayer(0);
                }
            }
        }
    

    public void onBackClicked()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnApplicationQuit()
    {
        networkController.GetComponent<NetworkController>().StopHost();
    }
}
