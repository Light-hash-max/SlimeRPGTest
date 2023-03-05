using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Кнопка старта
/// </summary>
public class StartButton : AbstractButtonView
{
    /// <summary>
    /// По старту
    /// </summary>
    public event Action onStart = delegate { };
    public override void OnButtonClicked() => onStart();
}
