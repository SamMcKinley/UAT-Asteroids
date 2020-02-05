using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public bool isPaused = false;
    public int lives = 3;
    public GameObject PlayerPrefab;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager.");
        }
        
    }

    public void Respawn()
    {
        Instantiate(PlayerPrefab);
    }
}

