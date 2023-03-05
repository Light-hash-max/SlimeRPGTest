using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Передвижение
/// </summary>
public class Movement : MonoBehaviour
{
    private Coroutine _moveCoroutine = null;

    /// <summary>
    /// Начать движение
    /// </summary>
    /// <param name="speed"></param>
    public void StartMovement(float speed)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }

        _moveCoroutine = StartCoroutine(MoveCoroutine(speed));
    }

    /// <summary>
    /// Остановить движение
    /// </summary>
    public void StopMovement()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }

    private IEnumerator MoveCoroutine(float speed)
    {
        while (enabled)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            yield return null;
        }
    }
}
