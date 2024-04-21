using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _personSprites = new List<Sprite>();

    [SerializeField]
    private Image _playerImage;

    [SerializeField]
    private Animator _playerAnimator;

    private readonly string _currentCharacterKey = "CharacterKey";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(_currentCharacterKey))
            PlayerPrefs.SetInt(_currentCharacterKey, 0);

        int currentCharacter = PlayerPrefs.GetInt(_currentCharacterKey, 0);


    }
}
