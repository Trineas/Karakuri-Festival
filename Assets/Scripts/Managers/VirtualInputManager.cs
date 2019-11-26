using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualInputManager : Singleton<VirtualInputManager>
{
    public bool MoveRight;
    public bool MoveLeft;
    public bool MoveUp;
    public bool MoveDown;
    public bool Jump;
    public bool DoubleJump;
    public bool Attack;
    public bool RangedAttack;
    public bool CharacterSwitchRight;
    public bool CharacterSwitchLeft;
}
