using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������� ����� ��� ��������
/// </summary>
[RequireComponent(typeof(Slider))]
public abstract class AbstractSliderView : MonoBehaviour
{

    [SerializeField]
    protected Text _damageText = default;
    protected Slider _slider = default;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
        Init();
    }

    /// <summary>
    /// �������������
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// ��������� �������� ��������
    /// </summary>
    /// <param name="value"></param>
    protected virtual void SetSliderValue(float value)
    {
        _slider.value = value;
        _damageText.GetComponent<CanvasGroup>().alpha = 1;

        if (LeanTween.isTweening(_damageText.gameObject))
        {
            LeanTween.cancel(_damageText.gameObject);
        }

        LeanTween.alphaCanvas(_damageText.GetComponent<CanvasGroup>(), 0f, 0.5f);
    }
}
