using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Детектор врага вблизи
/// </summary>
public class EnemyDetector : MonoBehaviour
{
    [SerializeField]
    private Player _player = default;

    private Enemy _enemy = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _enemy))
        {
            if(_enemy.GetComponent<EnemyHealthController>().IsKilled)
            {
                return;
            }
            _enemy.StartAttack();
            _player.StartGetDamage();
        }
    }
}
