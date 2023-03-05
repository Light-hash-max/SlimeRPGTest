using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поворачивает объекты в камеру
/// </summary>
public class LookAtCamera : MonoBehaviour
{
    private void Update() => transform.LookAt(Camera.main.transform);

}
