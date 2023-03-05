using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Статическая игравая дата
/// </summary>
public static class StaticGameData
{
    /// <summary>
    /// Уроан игрока
    /// </summary>
    public static float DamagePlayer
    {
        get => PlayerPrefs.GetFloat(nameof(DamagePlayer), 25f);

        set
        {
            PlayerPrefs.SetFloat(nameof(DamagePlayer), value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Скорость атаки игрока
    /// </summary>
    public static float AttackRatePlayer
    {
        get => PlayerPrefs.GetFloat(nameof(AttackRatePlayer), 2.1f);

        set
        {
            PlayerPrefs.SetFloat(nameof(AttackRatePlayer), value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Максимальное здоровье игрока
    /// </summary>
    public static float MaxHealth
    {
        get => PlayerPrefs.GetFloat(nameof(MaxHealth), 100f);

        set
        {
            PlayerPrefs.SetFloat(nameof(MaxHealth), value);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Максимальное здоровье игрока
    /// </summary>
    public static float SpeedPlayer
    {
        get => PlayerPrefs.GetFloat(nameof(SpeedPlayer), 3f);

        set
        {
            PlayerPrefs.SetFloat(nameof(SpeedPlayer), value);
            PlayerPrefs.Save();
        }
    }
}
