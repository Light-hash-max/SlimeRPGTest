using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������
/// </summary>
public class Movement : MonoBehaviour
{
    private Coroutine _moveCoroutine = null;

    /// <summary>
    /// ������ ��������
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
    /// ���������� ��������
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
