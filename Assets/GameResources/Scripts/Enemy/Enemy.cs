using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление врагом
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Начать атаку
    /// </summary>
    public static event Action onEnemyAttack = delegate { };

    [SerializeField]
    private EnemySparrowStateManager _enemySparrowStateManager = default;

    private Player _player = default;
    private bool _isAttacking = false;
    private TargetsManager _targetsManager = default;
    private CoinsCounter _coinsCounter = default;

    private Coroutine _attackingCoroutine = null;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _targetsManager = FindObjectOfType<TargetsManager>();
        _coinsCounter = FindObjectOfType<CoinsCounter>();
    }

    private IEnumerator Attacking()
    {
        while (enabled)
        {
            onEnemyAttack();
            yield return new WaitForSeconds(0.475f);
        }
    }

    /// <summary>
    /// Начать атаку
    /// </summary>
    public void StartAttack()
    {
        _enemySparrowStateManager.SwitchState(_enemySparrowStateManager._sparrowAttackingState);
        _isAttacking = true;

        if (_attackingCoroutine != null)
        {
            StopCoroutine(_attackingCoroutine);
            _attackingCoroutine = null;
        }

        _attackingCoroutine = StartCoroutine(Attacking());
    }

    private void LateUpdate()
    {
        if (_isAttacking)
        {
            transform.LookAt(_player.transform);
        }
    }

    /// <summary>
    /// Выставить цель
    /// </summary>
    public void SetTarget() => _targetsManager.AddObjectToTarget(gameObject);

    /// <summary>
    /// Умереть
    /// </summary>
    public void Kill()
    {
        if (_attackingCoroutine != null)
        {
            StopCoroutine(_attackingCoroutine);
            _attackingCoroutine = null;
        }
        _isAttacking = false;
        _enemySparrowStateManager.SwitchState(_enemySparrowStateManager._sparrowDeathState);
        _targetsManager.RemoveFromTarget(gameObject);
        StartCoroutine(Death());
        _coinsCounter.CurrentCount += 10;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
