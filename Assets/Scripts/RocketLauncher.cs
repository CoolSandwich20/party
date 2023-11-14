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
            RocketPull[0].rb.bodyType = RigidbodyType2D.Dynamic;
            RocketPull[0].gameObject.transform.position = transform.position;
            RocketPull[0].OnEnable();
            RocketPull.RemoveAt(0);
            LastLaunch = Time.time;
        }
    }
}
