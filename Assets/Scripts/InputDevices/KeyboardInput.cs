using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    void Update()
    {
        // move left and right
        if (Input.GetKey(KeyCode.D))
        {
            VirtualInputManager.Instance.MoveRight = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveRight = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            VirtualInputManager.Instance.MoveLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveLeft = false;
        }

        // move up and down
        if (Input.GetKey(KeyCode.W))
        {
            VirtualInputManager.Instance.MoveUp = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            VirtualInputManager.Instance.MoveDown = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveDown = false;
        }

        // jump
        if (Input.GetKey(KeyCode.Space))
        {
            VirtualInputManager.Instance.Jump = true;
        }

        else
        {
            VirtualInputManager.Instance.Jump = false;
        }

        // attack
        if (Input.GetKey(KeyCode.Return))
        {
            VirtualInputManager.Instance.Attack = true;
        }

        else
        {
            VirtualInputManager.Instance.Attack = false;
        }

        // ranged attack
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            VirtualInputManager.Instance.RangedAttack = true;
        }

        else
        {
            VirtualInputManager.Instance.RangedAttack = false;
        }

        // character switch
        if (Input.GetKeyDown(KeyCode.E))
        {
            VirtualInputManager.Instance.CharacterSwitchRight = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = false;
        }
    }
}
