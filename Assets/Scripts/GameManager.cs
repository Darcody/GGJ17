using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Determins if Lighthouse (0) or Boat (1)
    public static int playerRole = 0;
    public static bool isWin = false;
    public static bool isLose = false;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
