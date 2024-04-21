using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanelController : MonoBehaviour
{
    [SerializeField]
    private List<Image> _HPImages = new List<Image>();

    [SerializeField]
    private List<Sprite> _HPSprites = new List<Sprite>();

    [SerializeField]
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController.OnHealthChange.AddListener(HealthChange);
    }

    private void HealthChange(int health, int maxHealth)
    {
        if (health > 0)
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
}
