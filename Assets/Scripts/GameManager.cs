using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Determins if Lighthouse (0) or Boat (1)
    public static int playerRole = 0;
    public int pRole = 5;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pRole = playerRole;
	}
}
