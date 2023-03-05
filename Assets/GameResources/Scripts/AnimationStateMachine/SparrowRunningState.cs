using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Бег
/// </summary>
public class SparrowRunningState : SparrowBaseState
{
    private string TRIGGER_NAME = "Walk";

    public override void EnterState(SparrowStateManager sparrow)
    {
        base.EnterState(sparrow);
        _animator.SetTrigger(TRIGGER_NAME);
        _movement.StartMovement(5f);
    }

}
