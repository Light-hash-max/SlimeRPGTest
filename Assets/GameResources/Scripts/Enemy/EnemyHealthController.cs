using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Управлет здоровьем врага
/// </summary>
public class EnemyHealthController : MonoBehaviour
{
    /// <summary>
    /// Изменение значения здоровья
    /// </summary>
    public event Action<float> onHelthChanged = delegate { };

    /// <summary>
    /// Убит ли враг
    /// </summary>
    public bool IsKilled { get; private set; } = false;

    /// <summary>
    /// Максимальное значение здоровья
    /// </summary>
    public float MaxHealth  = 100f;

    /// <summary>
    /// Урон от пули
    /// </summary>
    public float BulletDamage => StaticGameData.DamagePlayer > MaxHealth ? MaxHealth : StaticGameData.DamagePlayer;

    [SerializeField]
    private Enemy _enemy = default;

    private float _currentHealth = 0f;

    private void OnEnable()
    {
        IsKilled = false;
        _currentHealth = MaxHealth;
    }

    /// <summary>
    /// Получить урон
    /// </summary>
    public void GetDamage()
    {
        _currentHealth -= BulletDamage;
        onHelthChanged(_currentHealth);
        if (_currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        IsKilled = true;
        _enemy.Kill();
    }
}
