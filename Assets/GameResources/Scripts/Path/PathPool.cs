using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул дороги
/// </summary>
public class PathPool : MonoBehaviour
{
    [SerializeField]
    private int _maxCountInPool = 3;
    [SerializeField]
    private Transform _parent = default;
    [SerializeField]
    private GameObject _pathBlock = default;

    private List<GameObject> pool = new List<GameObject>();

    /// <summary>
    /// Доставть из пула
    /// </summary>
    /// <returns></returns>
    public GameObject GetFromPool()
    {
        if (pool.Count < _maxCountInPool)
        {
            GameObject newPath = Instantiate(_pathBlock, _parent);
            pool.Add(newPath);
            newPath.GetComponent<SpawnEnemy>().Spawn();
            return newPath;
        }

        GameObject oldPath = pool[0];
        oldPath.GetComponent<PathController>().ChangeTrigger();
        pool.RemoveAt(0);
        pool.Add(oldPath);
        oldPath.GetComponent<SpawnEnemy>().Spawn();
        return oldPath;
    }
}
