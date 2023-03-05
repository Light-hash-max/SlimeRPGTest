using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление состояниями
/// </summary>
public class SparrowStateManager : MonoBehaviour
{
    private StartButton _startButton = default;
    public SparrowBaseState CurrentState = default;

    public SparrowIdleState _sparrowIdleState = new SparrowIdleState();
    public SparrowAttackingState _sparrowAttackingState = new SparrowAttackingState();
    public SparrowRunningState _sparrowRunningState = new SparrowRunningState();
    public SparrowWalkingState _sparrowWalkingState = new SparrowWalkingState();
    public SparrowDeathState _sparrowDeathState = new SparrowDeathState();

    private void Awake()
    {
        _startButton = FindObjectOfType<StartButton>();
        if (_startButton != null)
        {
            _startButton.onStart += StartPlayerAnimation;
        }
    }

    private void OnDestroy()
    {
        if (_startButton != null)
        {
            _startButton.onStart -= StartPlayerAnimation;
        }
    }

    protected virtual void StartPlayerAnimation() => SwitchState(_sparrowWalkingState);

    protected virtual void Start()
    {
        CurrentState = _sparrowIdleState;
        CurrentState.EnterState(this);
    }

    /// <summary>
    /// Изменить состояние
    /// </summary>
    /// <param name="newState"></param>
    public void SwitchState(SparrowBaseState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState(this);
    }
}
