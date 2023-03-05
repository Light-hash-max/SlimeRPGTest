using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул врагов
/// </summary>
public class PoolEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab = default;
    [SerializeField]
    private Transform _enemyParent = default;

    private List<GameObject> _pool = new List<GameObject>();

    public GameObject SpawnEnemy()
    {
        foreach (GameObject enemy in _pool)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                enemy.transform.rotation = _enemyPrefab.transform.rotation;
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(_enemyPrefab, _enemyParent);
        _pool.Add(newEnemy);
        return newEnemy;
    }
}
