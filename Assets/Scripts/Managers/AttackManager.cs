using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{
    public List<AttackInfo> CurrentAttacks = new List<AttackInfo>();
}
