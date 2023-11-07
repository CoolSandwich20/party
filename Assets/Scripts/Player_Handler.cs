using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Handler : MonoBehaviour
{
    [SerializeField] GameObject Guy;
    [SerializeField] GameObject Gal;
    [SerializeField] Rigidbody2D CoupleRB;
    [SerializeField] float MoveSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveCouple(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveCouple(false);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 10;
        }               
        else
        {
            MoveSpeed = 5;
        }

    }


    void MoveCouple(bool isLeft = false)
    {

        if (!isLeft) CoupleRB.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        if (isLeft) CoupleRB.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

    }
    
}
