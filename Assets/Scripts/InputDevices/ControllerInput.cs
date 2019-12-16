using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    void Update()
    {
        // move left and right
        if (Input.GetKey("Move LeftRight"))
        {
            VirtualInputManager.Instance.MoveRight = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveRight = false;
        }

        if (Input.GetKey("Move LeftRight"))
        {
            VirtualInputManager.Instance.MoveLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveLeft = false;
        }

        // move up and down
        if (Input.GetKey("Move UpDown"))
        {
            VirtualInputManager.Instance.MoveUp = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveUp = false;
        }

        if (Input.GetKey("Move UpDown"))
        {
            VirtualInputManager.Instance.MoveDown = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveDown = false;
        }

        // jump
        if (Input.GetKey("Jump"))
        {
            VirtualInputManager.Instance.Jump = true;
        }

        else
        {
            VirtualInputManager.Instance.Jump = false;
        }

        // attack
        if (Input.GetKey("Attack"))
        {
            VirtualInputManager.Instance.Attack = true;
        }

        else
        {
            VirtualInputManager.Instance.Attack = false;
        }

        // ranged attack
        if (Input.GetKey("Ranged Attack"))
        {
            VirtualInputManager.Instance.RangedAttack = true;
        }

        else
        {
            VirtualInputManager.Instance.RangedAttack = false;
        }

        // character switch
        if (Input.GetKeyDown("Character Switch"))
        {
            VirtualInputManager.Instance.CharacterSwitchRight = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchRight = false;
        }

        if (Input.GetKeyDown("Character Switch"))
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = false;
        }
    }
}
