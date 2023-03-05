using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ױמהüבא
/// </summary>
public class SparrowWalkingState : SparrowBaseState
{
    private string TRIGGER_NAME = "Walk";
    public override void EnterState(SparrowStateManager sparrow)
    {
        base.EnterState(sparrow);
        _animator.SetTrigger(TRIGGER_NAME);
        _movement.StartMovement(StaticGameData.SpeedPlayer);
    }

}
