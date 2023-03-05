using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление игроком
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private SparrowStateManager _sparrowStateManager = default;

    /// <summary>
    /// Получать урон
    /// </summary>
    public void StartGetDamage() => _sparrowStateManager.SwitchState(_sparrowStateManager._sparrowIdleState);

    /// <summary>
    /// Продолжить передвижение
    /// </summary>
    public void ContinueWalk() => _sparrowStateManager.SwitchState(_sparrowStateManager._sparrowWalkingState);
}
