using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управлет состояними врага
/// </summary>
public class EnemySparrowStateManager : SparrowStateManager
{

    private void OnEnable() => SwitchState(GameStatisData.IsStart ? _sparrowRunningState : _sparrowIdleState);

    protected override void Start() => SwitchState(GameStatisData.IsStart ? _sparrowRunningState : _sparrowIdleState);

    protected override void StartPlayerAnimation()
    {
        SwitchState(_sparrowRunningState);
        GameStatisData.IsStart = true;
    }
}
