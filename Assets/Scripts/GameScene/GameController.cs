using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private AudioController _audioController;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField]
    private TMP_Text _scoreResult;

    private TMP_Text _finalText;

    private int _repairedEngines = 0;

    private int _repaireEnginesCount = 7;

    private void Awake()
    {
        _playerController.OnFinish.AddListener(FinishGame);
        _playerController.OnHealthZero.AddListener(CheckHealthStatus);
    }

    //private void Start()
    //{
    //    _finalText = GameObject.FindGameObjectWithTag("FinalText").transform.GetComponent<TMP_Text>();
    //}

    private void CheckHealthStatus()
    {
        if (_losePanel != null)
            _losePanel.SetActive(true);

        _audioController.PlayLoseSound();
    }

    private void FinishGame()
    {
        if (_repairedEngines == _repaireEnginesCount)
        {
            if (_winPanel != null)
                _winPanel.SetActive(true);

            _scoreResult.text = "Твой счет: " + _playerController.Score.ToString();

            _audioController.PlayWinSound();
        }
        else
        {
            _finalText = GameObject.FindGameObjectWithTag("FinalText").transform.GetComponent<TMP_Text>();

            //Debug.Log("Need to repair all engines!");
            StartCoroutine(FinalTextCoroutine());
        }
    }

    private IEnumerator FinalTextCoroutine()
    {
        _finalText.text = "Чтобы покорить вершину, собери все части Российского ПК.";

        Vector3 newTextPos = new Vector3(_finalText.transform.position.x, _finalText.transform.position.y + 0.15f, _finalText.transform.position.z);

        _finalText.transform.position = Vector3.MoveTowards(_finalText.transform.position, newTextPos, 1.5f * Time.deltaTime);

        yield return new WaitForSeconds(2f);

        _finalText.text = "";

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
