using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Подсчет монет
/// </summary>
public class CoinsCounter : MonoBehaviour
{
    /// <summary>
    /// Изменения значения
    /// </summary>
    public event Action<int> onValueChanged = delegate { };

    /// <summary>
    /// Текущее значение
    /// </summary>
    public int CurrentCount
    {
        get => PlayerPrefs.GetInt("COINS COUNT", 0);

        set
        {
            PlayerPrefs.SetInt("COINS COUNT", value);
            PlayerPrefs.Save();
            onValueChanged(value);
        }
    }

    private void OnEnable() => onValueChanged(CurrentCount);


}
