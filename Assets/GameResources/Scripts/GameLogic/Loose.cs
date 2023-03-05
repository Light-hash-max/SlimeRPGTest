using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Проигрыш
/// </summary>
public class Loose : MonoBehaviour
{
    [SerializeField]
    private GameObject _enadGame = default;
    [SerializeField]
    private Button _restartButton = default;

    private PlayerHelth _playerHelth = default;

    private void Awake()
    {
        _playerHelth = FindObjectOfType<PlayerHelth>();
        _playerHelth.onEndGame += EndGame;
        _restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        _playerHelth.onEndGame -= EndGame;
        _restartButton.onClick.RemoveListener(Restart);
    }

    private void EndGame()
    {
        _enadGame.SetActive(true);
        Time.timeScale = 0f;
    }
}
