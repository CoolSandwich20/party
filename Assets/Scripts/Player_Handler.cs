using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Handler : MonoBehaviour
{
    [SerializeField] GameObject Guy;
    [SerializeField] GameObject Gal;
    [SerializeField] Rigidbody2D CoupleRB;
    [SerializeField] float MoveSpeed = 0;
    [SerializeField] SpriteRenderer CoupleSPrite;
    [SerializeField] Animator AnimatorCouple;
    public bool isControlsOn = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isControlsOn)
        {
            AnimatorCouple.SetBool("Moving", true);
            MoveCouple(true);
            CoupleSPrite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isControlsOn)
        {
            AnimatorCouple.SetBool("Moving", true);
            MoveCouple(false);
            CoupleSPrite.flipX = false;
        }
        else if (!(Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.RightArrow)) && isControlsOn)
        {
            AnimatorCouple.SetBool("Moving", false);
        }

        if(Input.GetKey(KeyCode.LeftShift) && isControlsOn)
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
