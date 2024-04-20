using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanelController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private List<Image> _HPImages = new List<Image>();

    [SerializeField]
    private List<Sprite> _HPSprites = new List<Sprite>();

    private void Start()
    {
        _playerController.OnHealthChange.AddListener(ChangeHealth);
        ChangeHealth(3, 3);
    }

    private void ChangeHealth(int health, int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            _HPImages[i].enabled = true;
        }

        for (int i = 0; i < health; i++)
        {
            _HPImages[i].sprite = _HPSprites[0];
        }

        for (int i = health; i < maxHealth; i++)
        {
            _HPImages[i].sprite = _HPSprites[1];
        }
    }
}
