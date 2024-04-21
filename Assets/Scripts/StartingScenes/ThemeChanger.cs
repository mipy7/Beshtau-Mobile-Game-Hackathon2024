using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChanger : MonoBehaviour
{
	private SpriteChangeBeehaviour[] themes;

	private string _themeKey = "themeKey";

	private void Awake()
	{
        if(!PlayerPrefs.HasKey(_themeKey))
            PlayerPrefs.SetInt(_themeKey, 0);
	}

	private void Start()
	{
		themes = FindObjectsOfType<SpriteChangeBeehaviour>();
	}

	public void ChangeTheme()
	{
		themes = FindObjectsOfType<SpriteChangeBeehaviour>();

		if (PlayerPrefs.GetInt(_themeKey, 0) == 0)
		{
			PlayerPrefs.SetInt(_themeKey, 1);
		}
		else
		{
			PlayerPrefs.SetInt(_themeKey, 0);
		}
		
		foreach(SpriteChangeBeehaviour changer in themes) { changer.ApplyTheme(); Debug.Log(changer.gameObject.name); }
	}
}
