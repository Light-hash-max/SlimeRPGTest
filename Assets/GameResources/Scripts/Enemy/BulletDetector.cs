using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Определяет попадание пули
/// </summary>
public class BulletDetector : MonoBehaviour
{
    [SerializeField]
    private EnemyHealthController _enemyHealthController = default;

    private BulletLiveTime _bullet = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BulletLiveTime>(out _bullet) && !_enemyHealthController.IsKilled)
        {
            _bullet.gameObject.SetActive(false);
            _enemyHealthController.GetDamage();
        }
    }
}
