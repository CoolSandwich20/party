using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] float LastLaunch;
    [SerializeField] float CoolDown;
    [SerializeField] Camera camera;
    public List<Rocket> RocketPull;
    void Start()
    {
        LastLaunch = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (LastLaunch + CoolDown < Time.time)
        {
            RocketPull[0].gameObject.SetActive(true);
            RocketPull.RemoveAt(0);
            LastLaunch = Time.time;
        }
    }
}
