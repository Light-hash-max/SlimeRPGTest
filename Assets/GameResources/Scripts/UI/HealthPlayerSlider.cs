using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Слайдер здоровья игрока
/// </summary>
public class HealthPlayerSlider : AbstractSliderView
{
    [SerializeField]
    private PlayerHelth _playerHelth = default;

    protected override void Awake()
    {
        base.Awake();
        _playerHelth.onGetDamage += SetSliderValue;
    }

    protected override void SetSliderValue(float value)
    {
        base.SetSliderValue(value);
        _damageText.text = _playerHelth.EnemyDamage.ToString();
    }

    private void OnEnable() => Init();

    private void OnDestroy() => _playerHelth.onGetDamage -= SetSliderValue;

    protected override void Init()
    {
        _slider.maxValue = _playerHelth.MaxHealth;
        _slider.value = _slider.maxValue;
        _slider.minValue = 0f;
    }
}
