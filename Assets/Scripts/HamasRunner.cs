using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamasRunner : MonoBehaviour
{
    [SerializeField] float Speed;

    void Update()
    {
        transform.Translate((GameManager.Instance.Player.transform.position - transform.position).normalized * Speed * Time.deltaTime);
        transform.position = new(transform.position.x,Mathf.Min(Mathf.Max(transform.position.y,1f),1.75f),transform.position.z);
        transform.localScale = Vector3.one*(2-(transform.position.y/0.75f*0.25f+0.5625f));
    }
}
