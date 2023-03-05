using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Жизнь пули
/// </summary>
public class BulletLiveTime : MonoBehaviour
{
    private float _liveTime = 5f;

    private void OnEnable() => StartCoroutine(Live());

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(_liveTime);
        gameObject.SetActive(false);
    }
}
