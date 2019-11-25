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
    }
}
