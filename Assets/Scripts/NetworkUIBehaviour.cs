using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkUIBehaviour : MonoBehaviour {

    public GameObject networkController;
    public InputField addressField;

    public void onHostGameClicked()
    {
        networkController.GetComponent<NetworkController>().StartHost();
        this.gameObject.SetActive(false);
    }

    public void onJoinGameClicked()
    {
        networkController.GetComponent<NetworkController>().StartClient();
        networkController.GetComponent<NetworkController>().networkAddress = addressField.text;
        this.gameObject.SetActive(false);
    }

    public void onBackClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}
