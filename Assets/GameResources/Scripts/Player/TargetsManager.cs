using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управляет целями
/// </summary>
public class TargetsManager : MonoBehaviour
{
    [SerializeField]
    private Ballistics _ballistics = default;
    [SerializeField]
    private Player _player = default;

    private List<GameObject> targets = new List<GameObject>();
    private float _bulletSpeed = 30f;

    private Coroutine _shootingCoroutine = null;

    /// <summary>
    /// Добавить объект в цель
    /// </summary>
    /// <param name="newTarget"></param>
    public void AddObjectToTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
        if (_shootingCoroutine == null)
        {
            _shootingCoroutine = StartCoroutine(AttackingCoroutine());
        }
    }

    /// <summary>
    /// Убрать объект из цели
    /// </summary>
    /// <param name="oldTarget"></param>
    public void RemoveFromTarget(GameObject oldTarget)
    {
        targets.RemoveAll(item => item == oldTarget);

        if (targets.Count == 0)
        {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
            _player.ContinueWalk();
        }
    }

    private IEnumerator AttackingCoroutine()
    {
        while (targets.Count != 0)
        {
            _ballistics.Shot(targets[0].transform,_bulletSpeed);
            yield return new WaitForSeconds(StaticGameData.AttackRatePlayer);
        }
    }
}
