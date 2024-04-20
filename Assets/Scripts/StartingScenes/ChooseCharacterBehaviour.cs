using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseCharacterBehaviour : MonoBehaviour
{
    [SerializeField]
    private CharacterParams[] characters;

	[SerializeField]
	private TMP_Text nameField;
	[SerializeField]
	private TMP_Text descriptionField;
	[SerializeField]
	private Transform textureField;

	private int currentCharacter = 0;

    // Start is called before the first frame update
    void Start()
    {
		
    }

	// Update is called once per frame
	void Update()
    {
		if(currentCharacter >= 0 && currentCharacter < characters.Length)
		{
			nameField.text = characters[currentCharacter].CharacterName;
			descriptionField.text = characters[currentCharacter].CharacterDescription;
			characters[currentCharacter].gameObject.SetActive(true);
			characters[currentCharacter].gameObject.transform.position = textureField.position;
		}
	}

}
