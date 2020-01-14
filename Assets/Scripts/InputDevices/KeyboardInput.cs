using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    void Update()
    {
        // move left and right
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.1f)
        {
            VirtualInputManager.Instance.MoveRight = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveRight = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < -0.1f)
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            VirtualInputManager.Instance.Jump = true;
        }

        else
        {
            VirtualInputManager.Instance.Jump = false;
        }

        // attack
        if (Input.GetKey(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            VirtualInputManager.Instance.Attack = true;
        }

        else
        {
            VirtualInputManager.Instance.Attack = false;
        }

        // ranged attack
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            VirtualInputManager.Instance.RangedAttack = true;
        }

        else
        {
            VirtualInputManager.Instance.RangedAttack = false;
        }

        // character switch
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            VirtualInputManager.Instance.CharacterSwitchRight = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.CharacterSwitchLeft = false;
        }
    }
}
