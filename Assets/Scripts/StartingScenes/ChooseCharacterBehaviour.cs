using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseCharacterBehaviour : MonoBehaviour
{
	private readonly string _currentCharacterKey = "CharacterKey";

	[SerializeField] GameObject[] characters;
	private int currentCharacter = 0;

	private void Awake()
	{
		if (!PlayerPrefs.HasKey(_currentCharacterKey))
			PlayerPrefs.SetInt(_currentCharacterKey, 0);
		
	}

	// Start is called before the first frame update
	void Start()
    {
		
    }

	// Update is called once per frame
	void Update()
    {

	}

	public void PrevButton()
	{
		if (currentCharacter > 0)
		{
			characters[currentCharacter].gameObject.SetActive(false);
			currentCharacter--;
			characters[currentCharacter].gameObject.SetActive(true);
		}
	}

	public void NextButton()
	{
		if (currentCharacter < characters.Length)
		{
			characters[currentCharacter].gameObject.SetActive(false);
			currentCharacter++;
			characters[currentCharacter].gameObject.SetActive(true);
		}
	}

	public void ChooseCharacter()
	{
		PlayerPrefs.SetInt(_currentCharacterKey, currentCharacter);
	}
}
