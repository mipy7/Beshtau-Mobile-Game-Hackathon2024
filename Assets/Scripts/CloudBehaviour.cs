using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudBehaviour : MonoBehaviour
{
	private float speed;
	private bool flipX;
	private float opacity;
	private Vector2 spawnPos;
	private float scale;

	private Rigidbody2D _rb;

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
		ResetScript();
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
			ResetScript();
		}
    }

	private void ResetScript()
	{
		InitializeField();
		_rb.velocity = Vector2.left * speed;
	}

	private void InitializeField()
	{
		speed = Random.Range(5f, 10f);
		flipX = Random.Range(0f, 10f) > 5;
		opacity = Random.Range(0.5f, 1f);
		spawnPos = new Vector2(Screen.width/2 + Random.Range(0f, 20f), Screen.height/3 - Random.Range(0f, 20f));
		scale = Random.Range(0.8f, 1f);
	}
}