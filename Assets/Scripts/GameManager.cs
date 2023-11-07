using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player_Handler Player;

    void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
       
    }


    void Update()
    {
        
    }
}
