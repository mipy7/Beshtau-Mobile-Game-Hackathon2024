using System;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class CloudBehaviour : MonoBehaviour
{
	private float speed;
	private bool flipX;
	private float opacity;
	private Vector2 spawnPos;
	private float scale;

	private Rigidbody2D _rb;

	private SpriteRenderer _sprite;

	// Start is called before the first frame update
	void Start()
    {
		if (TryGetComponent(out Rigidbody2D rb))
		{
			_rb = rb;
		}
		else
		{
			new NullReferenceException("Check Player RigidBody!");
		}

		if (TryGetComponent(out SpriteRenderer sprite))
		{
			_sprite = sprite;
		}
		else
		{
			new NullReferenceException("Check Player RigidBody!");
		}
		
		ResetScript();
	}

    // Update is called once per frame
    void Update()
    {
		float resetPosX = -(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + _sprite.bounds.size.x);
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
		_sprite.flipX = flipX;
		_sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, opacity);
		transform.localScale = Vector3.one * scale;
	}

	private void InitializeField()
	{
		speed = Random.Range(0.2f, 1.5f);
		flipX = Random.Range(0f, 10f) > 5;
		opacity = Random.Range(0.5f, 1f);
		spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) + new Vector3( _sprite.bounds.size.x + Random.Range(0f, 10f), -Random.Range(1f, 3f), 0);
		scale = Random.Range(0.8f, 1f);
	}
}