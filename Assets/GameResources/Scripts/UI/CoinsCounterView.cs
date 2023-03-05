using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Отображение подсчета монет
/// </summary>
[RequireComponent(typeof(Text))]
public class CoinsCounterView : MonoBehaviour
{
    private CoinsCounter _coinsCounter = default;
    private Text _text = default;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _coinsCounter = FindObjectOfType<CoinsCounter>();
        _coinsCounter.onValueChanged += ChangeView;
    }

    private void OnDestroy() => _coinsCounter.onValueChanged -= ChangeView;

    private void ChangeView(int value) => _text.text = value.ToString();
}
