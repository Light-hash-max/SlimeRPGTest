using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ������
/// </summary>
public class StartButton : AbstractButtonView
{
    /// <summary>
    /// �� ������
    /// </summary>
    public event Action onStart = delegate { };
    public override void OnButtonClicked() => onStart();
}
