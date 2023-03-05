using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Слайдер здоровья врага
/// </summary>
public class HealthEnemySlider : AbstractSliderView
{
    [SerializeField]
    private EnemyHealthController _enemyHealthController = default;

    protected override void Awake()
    {
        base.Awake();
        _enemyHealthController.onHelthChanged += SetSliderValue;
    }

    protected override void SetSliderValue(float value)
    {
        base.SetSliderValue(value);
        _damageText.text = _enemyHealthController.BulletDamage.ToString();
    }

    private void OnEnable() => Init();

    private void OnDestroy() => _enemyHealthController.onHelthChanged -= SetSliderValue;

    protected override void Init()
    {
        _slider.maxValue = _enemyHealthController.MaxHealth;
        _slider.value = _slider.maxValue;
        _slider.minValue = 0f;
    }
}
