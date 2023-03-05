using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Смерть
/// </summary>
public class SparrowDeathState : SparrowBaseState
{
    private string TRIGGER_NAME = "Death";
    public override void EnterState(SparrowStateManager sparrow)
    {
        base.EnterState(sparrow);
        _animator.SetTrigger(TRIGGER_NAME);
        _movement.StopMovement();
    }

}