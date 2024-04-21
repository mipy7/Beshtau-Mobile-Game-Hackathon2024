using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusTimeCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private const float TIME = 30f;

    private float _time;

    private void Update()
    {
        if (_time > 0f)
        {
            _time -= Time.deltaTime;
            int intTime = (int)_time;
            _text.text = intTime.ToString();
        }
        else
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _time = TIME;
    }
}
