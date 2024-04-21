using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField]
    private TMP_Text _scoreResult;

    private int _repairedEngines = 0;

    private int _repaireEnginesCount = 7;

    private void Awake()
    {
        _playerController.OnFinish.AddListener(FinishGame);
        _playerController.OnHealthZero.AddListener(CheckHealthStatus);
    }

    private void CheckHealthStatus()
    {
        if (_losePanel != null)
            _losePanel.SetActive(true);
    }

    private void FinishGame()
    {
        if (_repairedEngines == _repaireEnginesCount)
        {
            if (_winPanel != null)
                _winPanel.SetActive(true);

            _scoreResult.text = "Твой счет: " + _playerController.Score.ToString();
        }
        else
        {
            Debug.Log("Need to repair all engines!");
        }
    }

    public void IncreaseRepairedEnginesCount()
    {
        if (_repairedEngines != _repaireEnginesCount)
        {
            _repairedEngines++;
            Debug.Log("Repaired engines " + _repairedEngines);
        }
        else
        {
            Debug.Log("All engines repaired");
        }
    }
}
