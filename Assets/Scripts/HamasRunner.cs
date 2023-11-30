using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamasRunner : MonoBehaviour 
{
    [SerializeField] float Speed;
    [SerializeField] bool isFarAway = false;
    [SerializeField] Animator Wolf;

    void Update()
    {
        if(!Wolf.GetBool("isAttacking")) transform.Translate((GameManager.Instance.Player.transform.position - transform.position).normalized * Speed * Time.deltaTime);
        //transform.position = new(transform.position.x,Mathf.Min(Mathf.Max(transform.position.y,1f),1.75f),transform.position.z);
        //transform.localScale = Vector3.one*(2-(transform.position.y/0.75f*0.25f+0.5625f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StoryPoint"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Player"))
        {
            Wolf.SetBool("isAttacking", true);
            Wolf.Play("Attack");
            Debug.Log("This Nuts");
            GameManager.Instance.Player.isControlsOn = false;//QuickTime Event
        }
    }
}
