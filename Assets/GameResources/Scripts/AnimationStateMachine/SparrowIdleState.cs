using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Состояние спокойствия
/// </summary>
public class SparrowIdleState : SparrowBaseState
{
    private string TRIGGER_NAME = "Idle";

    public override void EnterState(SparrowStateManager sparrow)
    {
        base.EnterState(sparrow);
        _animator.SetTrigger(TRIGGER_NAME);
        _movement.StopMovement();
    }

}