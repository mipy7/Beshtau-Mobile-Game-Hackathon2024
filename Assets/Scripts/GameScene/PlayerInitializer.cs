using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _personSprites = new List<Sprite>();

    [SerializeField]
    private SpriteRenderer _playerSprite;

	[SerializeField]
	private Animator _playerAnimator;

	[SerializeField]
	private List<AnimatorController> _personControllers = new List<AnimatorController>();

	private readonly string _currentCharacterKey = "CharacterKey";

	private int currentCharacter;


	private void Awake()
    {
        if (!PlayerPrefs.HasKey(_currentCharacterKey))
            PlayerPrefs.SetInt(_currentCharacterKey, 0);

        currentCharacter = PlayerPrefs.GetInt(_currentCharacterKey, 0);
	}

	private void Start()
	{
		_playerSprite.sprite = _personSprites[currentCharacter];

		_playerAnimator.runtimeAnimatorController = _personControllers[currentCharacter];
	}
}
