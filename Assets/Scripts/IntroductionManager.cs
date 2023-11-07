using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] GameObject movementButtons;
    [SerializeField] GameObject RunButton;
    [SerializeField] GameObject JumpButton;
    [SerializeField] GameObject CrouchButton;
    private void Update()
    {
        if (movementButtons != null && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            Destroy(movementButtons);
        }
        if (RunButton != null && Input.GetKey(KeyCode.LeftShift))
        {
            Destroy (RunButton);
        }
    }
}
