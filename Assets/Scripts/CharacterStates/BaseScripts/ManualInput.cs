using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl characterControl;

    private void Awake()
    {
        characterControl = this.gameObject.GetComponent<CharacterControl>();
    }

    void Update()
    {
        // move left and right
        if (VirtualInputManager.Instance.MoveRight)
        {
            characterControl.MoveRight = true;
        }

        else
        {
            characterControl.MoveRight = false;
        }

        if (VirtualInputManager.Instance.MoveLeft)
        {
            characterControl.MoveLeft = true;
        }

        else
        {
            characterControl.MoveLeft = false;
        }

        // jump
        if (Input.GetKey(KeyCode.Space))
        {
            characterControl.Jump = true;
        }

        else
        {
            characterControl.Jump = false;
        }

        // attack
        if (Input.GetKey(KeyCode.Return))
        {
            characterControl.Attack = true;
        }

        else
        {
            characterControl.Attack = false;
        }
    }
}
