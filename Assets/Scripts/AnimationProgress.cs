using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationProgress : MonoBehaviour
{
    public bool Jumped;
    public bool CameraShaken = false;
    public List<PoolObjectType> PoolObjectList = new List<PoolObjectType>();
    public bool JumpTriggered;
    public float MaxPressTime;

    private CharacterControl control;
    private float PressTime;

    [Header("Projectiles")]
    public Coroutine SpawnProjectilesRoutine;

    public void Awake()
    {
        control = GetComponentInParent<CharacterControl>();
        PressTime = 0f;
    }

    private void Update()
    {
        if (control.Jump)
        {
            PressTime += Time.deltaTime;
        }

        else
        {
            PressTime = 0f;
        }

        if (PressTime == 0f)
        {
            JumpTriggered = false;
        }

        else if (PressTime > MaxPressTime)
        {
            JumpTriggered = false;
        }

        else
        {
            JumpTriggered = true;
        }
    }

    public void SpawnProjectiles(SpawnProjectiles spawnData)
    {
        if (SpawnProjectilesRoutine == null)
        {
            SpawnProjectilesRoutine = StartCoroutine(_SpawnProjectiles(spawnData));
        }
    }

    IEnumerator _SpawnProjectiles(SpawnProjectiles spawnData)
    {
        for (int i = 0; i < spawnData.Amount; i++)
        {
            GameObject obj = PoolManager.Instance.GetObject(PoolObjectType.BOWL);

            GameObject pos = control.GetChildObj(spawnData.SpawnPosition);
            obj.transform.position = pos.transform.position;

            Projectile pro = obj.GetComponent<Projectile>();
            pro.control = control;
            pro.InitProjectile();

            yield return new WaitForSeconds(spawnData.Interval);
        }
    }
}