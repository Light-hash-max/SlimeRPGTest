using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� ������
/// </summary>
public class PathGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _parent = default;
    [SerializeField]
    private PathPool _pathPool = default;

    private void Awake() => SpawnBlock(_parent.position);

    /// <summary>
    /// ���������� ������
    /// </summary>
    /// <param name="newPosition"></param>
    public void SpawnBlock(Vector3 newPosition)
    {
        GameObject path = _pathPool.GetFromPool();
        path.transform.position = newPosition;
    }
}
