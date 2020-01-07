using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    ATTACKINFO,
    LADLE,
    BOWL,
    BOMB,
    FIREBALL,
    RIFLE,
    CORK,
    BELLYFLOP_VFX,
}

public class PoolObjectLoader : MonoBehaviour
{
    public static PoolObject InstantiatePrefab(PoolObjectType objType)
    {
        GameObject obj = null;

        switch (objType)
        {
            case PoolObjectType.ATTACKINFO:
                {
                    obj = Instantiate(Resources.Load("AttackInfo", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.LADLE:
                {
                    obj = Instantiate(Resources.Load("Ladle", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.BOWL:
                {
                    obj = Instantiate(Resources.Load("Bowl", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.BOMB:
                {
                    obj = Instantiate(Resources.Load("Bomb", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.BELLYFLOP_VFX:
                {
                    obj = Instantiate(Resources.Load("VFX_HammerDown", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.FIREBALL:
                {
                    obj = Instantiate(Resources.Load("Fireball", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.RIFLE:
                {
                    obj = Instantiate(Resources.Load("RIFLE", typeof(GameObject)) as GameObject);
                    break;
                }
            case PoolObjectType.CORK:
                {
                    obj = Instantiate(Resources.Load("CORK", typeof(GameObject)) as GameObject);
                    break;
                }
        }

        return obj.GetComponent<PoolObject>();
    }
}
