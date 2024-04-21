using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private TMP_Text _text;

    private void Awake()
    {
        _playerController.OnScoreChange.AddListener(ScoreChange);
    }

    private void ScoreChange(int score)
    {
        _text.text = score.ToString();
    }
}
