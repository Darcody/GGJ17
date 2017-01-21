using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatHit : MonoBehaviour {
    public GameObject toSink;
    public GameObject sinking;
    private GameObject uiObject;

    bool sunk = false;
    // Use this for initialization
    void Start () {
        uiObject = GameObject.Find("UI");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain") {
            // Destroy(this);
            if (sunk == false) {
                print("Lose");
                Instantiate(sinking, this.transform.position, this.transform.rotation);
                GetComponent<BoatMovement>().enabled = false;
                Destroy(toSink.gameObject);
                sunk = true;
                Network.Disconnect();
                uiObject.GetComponent<ShowPanels>().ShowLosePanel();
                GameManager.isLose = true;
            }
          
        }

        if(collision.gameObject.tag == "Harbour")
        {
            print("Win");
            Network.Disconnect();
            uiObject.GetComponent<ShowPanels>().ShowWinPanel();
            GameManager.isWin = true;
            //SceneManager.LoadScene("WinScene", LoadSceneMode.Additive);
            
            GetComponent<BoatMovement>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harbour")
        {
            print("Win");
            Network.Disconnect();
            uiObject.GetComponent<ShowPanels>().ShowWinPanel();
            GameManager.isWin = true;
            //SceneManager.LoadScene("WinScene", LoadSceneMode.Additive);

            GetComponent<BoatMovement>().enabled = false;
        }
    }
}
