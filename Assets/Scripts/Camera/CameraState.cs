using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CameraController.CameraTrigger[] arr = System.Enum.GetValues(typeof(CameraController.CameraTrigger)) as CameraController.CameraTrigger[];

        foreach (CameraController.CameraTrigger t in arr)
        {
            CameraManager.Instance.CAM_CONTROLLER.ANIMATOR.ResetTrigger(t.ToString());
        }
    }
}
