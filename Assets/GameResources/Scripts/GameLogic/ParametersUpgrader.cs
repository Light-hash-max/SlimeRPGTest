using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Обновляет значение параметров
/// </summary>
public class ParametersUpgrader : MonoBehaviour
{
    [SerializeField]
    private Button _upgradeDamage = default;
    [SerializeField]
    private Button _upgradeAttackRate = default;
    [SerializeField]
    private Button _upgradeMaxHealth = default;
    [SerializeField]
    private Button _upgradeSpeed = default;
    [SerializeField]
    private SparrowStateManager _player = default;

    private CoinsCounter _coinsCounter = default;

    private void Awake()
    {
        _coinsCounter = FindObjectOfType<CoinsCounter>();
        _coinsCounter.onValueChanged += CheckButtons;
        _upgradeDamage.onClick.AddListener(UpgradeDamage);
        _upgradeAttackRate.onClick.AddListener(UpgradeAttackRate);
        _upgradeMaxHealth.onClick.AddListener(UpgradeMaxHealth);
        _upgradeSpeed.onClick.AddListener(UpgradeSpeed);
    }

    private void CheckButtons(int value)
    {
        _upgradeDamage.interactable = _coinsCounter.CurrentCount >= 10;
        _upgradeAttackRate.interactable = _coinsCounter.CurrentCount >= 10 && StaticGameData.AttackRatePlayer > 0.1f;
        _upgradeMaxHealth.interactable = _coinsCounter.CurrentCount >= 10;
        _upgradeSpeed.interactable = _coinsCounter.CurrentCount >= 10;
    }

    private void OnDestroy()
    {
        _coinsCounter.onValueChanged -= CheckButtons;
        _upgradeDamage.onClick.RemoveListener(UpgradeDamage);
        _upgradeAttackRate.onClick.RemoveListener(UpgradeAttackRate);
        _upgradeMaxHealth.onClick.RemoveListener(UpgradeMaxHealth);
        _upgradeSpeed.onClick.RemoveListener(UpgradeSpeed);
    }

    private void UpgradeDamage()
    {
        StaticGameData.DamagePlayer += 10f;
        _coinsCounter.CurrentCount -= 10;
    }

    private void UpgradeAttackRate()
    {
        StaticGameData.AttackRatePlayer -= 0.5f;
        _coinsCounter.CurrentCount -= 10;
    }

    private void UpgradeSpeed()
    {
        if (_player.CurrentState == _player._sparrowWalkingState)
        {
            _player.SwitchState(_player._sparrowWalkingState);
        }

        StaticGameData.SpeedPlayer += 1f;
        _coinsCounter.CurrentCount -= 10;
    }

    private void UpgradeMaxHealth()
    {
        StaticGameData.MaxHealth += 10f;
        _coinsCounter.CurrentCount -= 10;
    }
}
