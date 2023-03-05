using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ”правлет логикой на тропинке
/// </summary>
public class PathController : MonoBehaviour
{
    [SerializeField]
    private Transform _newPosition = default;

    private Player _player = default;
    private PathGenerator _pathGenerator = default;
    private bool _isTrigger = false;

    /// <summary>
    /// ќбнулить триггер
    /// </summary>
    public void ChangeTrigger() => _isTrigger = false;

    private void Awake() => _pathGenerator = FindObjectOfType<PathGenerator>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player) &&!_isTrigger)
        {
            _isTrigger = true;
            _pathGenerator.SpawnBlock(_newPosition.position);
        }
    }
}
