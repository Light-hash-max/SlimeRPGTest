using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ���������� ������
/// </summary>
public class SpawnEnemy : MonoBehaviour
{
    private const float CHANCE = 0.5f;

    [SerializeField]
    private Transform[] _allSpawnPoints = default;

    private PoolEnemy _poolEnemy = default;

    private void Awake() => _poolEnemy = GetComponent<PoolEnemy>();

    /// <summary>
    /// ���������� �����
    /// </summary>
    public void Spawn()
    {
        foreach (Transform transformPoint in _allSpawnPoints)
        {
            if (Random.Range(0f, 1f) >= CHANCE)
            {
                GameObject enemy = _poolEnemy.SpawnEnemy();
                enemy.transform.position = transformPoint.position;
            }
        }
    }
}
