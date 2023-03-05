using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �������
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private SparrowStateManager _sparrowStateManager = default;

    /// <summary>
    /// �������� ����
    /// </summary>
    public void StartGetDamage() => _sparrowStateManager.SwitchState(_sparrowStateManager._sparrowIdleState);

    /// <summary>
    /// ���������� ������������
    /// </summary>
    public void ContinueWalk() => _sparrowStateManager.SwitchState(_sparrowStateManager._sparrowWalkingState);
}
