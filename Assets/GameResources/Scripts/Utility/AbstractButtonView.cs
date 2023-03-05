using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����������� ������
/// </summary>
[RequireComponent(typeof(Button))]
public abstract class AbstractButtonView : MonoBehaviour
{
    private Button _button = default;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy() => _button.onClick.RemoveListener(OnButtonClicked);

    /// <summary>
    /// ������� ������
    /// </summary>
    public abstract void OnButtonClicked();
}
