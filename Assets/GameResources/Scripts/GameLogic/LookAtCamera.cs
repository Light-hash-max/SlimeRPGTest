using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������ ������� � ������
/// </summary>
public class LookAtCamera : MonoBehaviour
{
    private void Update() => transform.LookAt(Camera.main.transform);

}
