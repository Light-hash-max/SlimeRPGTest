using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ������
/// </summary>
public class PlayerHelth : MonoBehaviour
{
    /// <summary>
    /// ��������� �����
    /// </summary>
    public event Action<float> onGetDamage = delegate { };

    /// <summary>
    /// ��������� ����
    /// </summary>
    public event Action onEndGame = delegate { };

    /// <summary>
    /// ���� �� �����
    /// </summary>
    public float EnemyDamage = 1f;

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public float MaxHealth => StaticGameData.MaxHealth;

    private float _currentHealth = 0f;

    private void Awake() => Enemy.onEnemyAttack += GetDamage;

    private void OnDestroy() => Enemy.onEnemyAttack -= GetDamage;

    private void OnEnable() => _currentHealth = MaxHealth;

    private void GetDamage()
    {
        _currentHealth -= EnemyDamage;
        onGetDamage(_currentHealth);

        if (_currentHealth <= 0f)
        {
            onEndGame();
        }
    }
}
