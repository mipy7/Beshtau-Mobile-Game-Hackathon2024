using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesController : MonoBehaviour
{
    private PlayerController _player;

    private HealthPanelController _healthPanelController;

    private float _timer = 30f;

    private void Awake()
    {
        if (TryGetComponent(out PlayerController player))
        {
            _player = player;
        }
        else
        {
            new NullReferenceException("Check PlayerController script!");
        }

        _healthPanelController = FindObjectOfType<HealthPanelController>();
    }

    private void Start()
    {
        _player.OnHealthBonus.AddListener(HealthBonusCollected);
        _player.OnShieldBonus.AddListener(ShieldBonusCollected);
        _player.OnScoreBonus.AddListener(ScoreBonusCollected);
    }

    private void HealthBonusCollected()
    {
        _player.MaxHealthIncrease();
        //_healthPanelController
    }

    private void ShieldBonusCollected()
    {
        StartCoroutine(ShieldCoroutine());
    }

    private void ScoreBonusCollected()
    {
        StartCoroutine(ScoreCoroutine());
    }

    private IEnumerator ShieldCoroutine()
    {
        Debug.Log("Shield Bonus Activated");
        
        _player.IsShieldBonusActive = true;

        yield return new WaitForSeconds(_timer);

        _player.IsShieldBonusActive = false;
        
        Debug.Log("Shield Bonus Deactivated");
    }

    private IEnumerator ScoreCoroutine()
    {
        Debug.Log("Score Bonus Activated");

        _player.IsScoreBonusActive = true;

        yield return new WaitForSeconds(_timer);

        _player.IsScoreBonusActive = false;

        Debug.Log("Score Bonus Deactivated");
    }
}
