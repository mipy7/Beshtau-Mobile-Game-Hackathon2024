using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChangeBeehaviour : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite[] sprite;

	private string _themeKey = "themeKey";

	private void Awake()
	{
		if (!PlayerPrefs.HasKey(_themeKey))
			PlayerPrefs.SetInt(_themeKey, 0);
	}

	private void Start()
	{
		ApplyTheme();
	}

	public void ApplyTheme()
	{
		var themeInt = PlayerPrefs.GetInt(_themeKey, 0);
		if (image != null)
		{
			Debug.Log(themeInt);
			if (sprite.Length > themeInt && sprite[themeInt] != null)
				image.sprite = sprite[themeInt];
		}
		else
		{
			if (sprite.Length > themeInt && sprite[themeInt] != null)
				spriteRenderer.sprite = sprite[themeInt];
		}
	}
}
