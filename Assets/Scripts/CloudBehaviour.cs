using System;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CloudBehaviour : MonoBehaviour
{
	private float speed;
	private float opacity;
	private Vector2 spawnPos;
	private float scale;

	private Rigidbody2D _rb;
	private Image _image;

	// Start is called before the first frame update
	void Start()
    {
		if (TryGetComponent(out Rigidbody2D rb))
		{
			_rb = rb;
		}
		else
		{
			new NullReferenceException("Check Cloud RigidBody!");
		}

		if (TryGetComponent(out Image image))
		{
			_image = image;
		}
		else
		{
			new NullReferenceException("Check Cloud Image!");
		}

		ResetScript();
	}

    // Update is called once per frame
    void Update()
    {
		float resetPosX = -(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + _image.sprite.bounds.size.x);
		if (transform.position.x < resetPosX)
		{
			ResetScript();
		}
    }

	private void ResetScript()
	{
		InitializeField();
		_rb.velocity = Vector2.left * speed;
		transform.position = spawnPos;
		_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, opacity);
		transform.localScale = Vector3.one * scale;
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
	}

	private void InitializeField()
	{
		speed = Random.Range(0.2f, 1.5f);
		opacity = Random.Range(0.5f, 1f);
		spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) + new Vector3(_image.sprite.bounds.size.x + Random.Range(0f, 10f), -Random.Range(1f, 3f), 0);
		scale = Random.Range(0.2f, 0.4f);
	}
}