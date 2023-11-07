using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player_Handler Player;
    public Image gripBar;
    public Volume gripVolume;
    public float Grip;

    void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
       
    }


    void Update()
    {
        gripBar.rectTransform.sizeDelta = new Vector2(100, 4 * Grip);
        ((Vignette)gripVolume.profile.components[0]).intensity.value = (100f - Grip) / 150f;
    }
}
