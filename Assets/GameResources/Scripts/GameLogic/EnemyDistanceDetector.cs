using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Детектирует врагов на расстоянии
/// </summary>
public class EnemyDistanceDetector : MonoBehaviour
{
    private Enemy _enemy = default;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _enemy))
        {
            _enemy.SetTarget();
        }
    }
}
