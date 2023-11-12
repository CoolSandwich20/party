using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] RocketLauncher launcher;
    void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        force = Random.Range(1f, 5f);
        rb.AddForce(Vector3.right * force * 10, ForceMode2D.Impulse);
        gameObject.transform.localScale = Vector3.one * ((force / 16f) + 0.1875f)/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 9 - (force / 4f * 5f) + 0.75f)
        {
            gameObject.SetActive(false);
            launcher.RocketPull.Add(this);
        }
    }
}
