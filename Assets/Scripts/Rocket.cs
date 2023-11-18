using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] RocketLauncher launcher;
    public void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        force = Random.Range(1f, 5f);
        rb.AddForce(Vector3.right * force * 10, ForceMode2D.Impulse);
        gameObject.transform.localScale = Vector3.one * ((force / 16f) + 0.1875f)/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Static) { return; }
        if (transform.position.y < 9 - (force / 4f * 5f) + 0.75f)
        {
            rb.bodyType = RigidbodyType2D.Static;
            launcher.RocketPull.Add(this);
        }
    }
}
