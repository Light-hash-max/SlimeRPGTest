using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Атака
/// </summary>
public class SparrowAttackingState : SparrowBaseState
{
    private string TRIGGER_NAME = "Attack";
    public override void EnterState(SparrowStateManager sparrow)
    {
        base.EnterState(sparrow);
        _animator.SetTrigger(TRIGGER_NAME);
        _movement.StopMovement();
    }

}