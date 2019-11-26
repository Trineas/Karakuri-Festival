﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Coroutine routine;

    private CameraController cameraController;
    public CameraController CAM_CONTROLLER
    {
        get
        {
            if (cameraController == null)
            {
                cameraController = GameObject.FindObjectOfType<CameraController>();
            }

            return cameraController;
        }
    }

    IEnumerator _CamShake(float sec)
    {
        CAM_CONTROLLER.TriggerCamera(CameraController.CameraTrigger.Shake);
        yield return new WaitForSeconds(sec);
        CAM_CONTROLLER.TriggerCamera(CameraController.CameraTrigger.Default);
    }

    public void ShakeCamera(float sec)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = StartCoroutine(_CamShake(sec));
    }
}