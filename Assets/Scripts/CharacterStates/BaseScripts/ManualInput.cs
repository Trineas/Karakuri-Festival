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

        // move up and down
        if (VirtualInputManager.Instance.MoveUp)
        {
            characterControl.MoveUp = true;
        }

        else
        {
            characterControl.MoveUp = false;
        }

        if (VirtualInputManager.Instance.MoveDown)
        {
            characterControl.MoveDown = true;
        }

        else
        {
            characterControl.MoveDown = false;
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            characterControl.Attack = true;
        }

        else
        {
            characterControl.Attack = false;
        }

        // ranged attack
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            characterControl.RangedAttack = true;
        }

        else
        {
            characterControl.RangedAttack = false;
        }

        // character switch
        if (Input.GetKeyDown(KeyCode.E))
        {
            characterControl.CharacterSwitchRight = true;
        }

        else
        {
            characterControl.CharacterSwitchRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            characterControl.CharacterSwitchLeft = true;
        }

        else
        {
            characterControl.CharacterSwitchLeft = false;
        }
    }
}
