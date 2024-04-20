using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParams : MonoBehaviour
{
	public String CharacterName;

	[TextAreaAttribute]
	public String CharacterDescription;

	public Texture2D CharacterTexture;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnValidate()
	{
		if (CharacterName.Length > 20)
		{
			CharacterName = CharacterName.Substring(0, 20);
		}
	}
}
