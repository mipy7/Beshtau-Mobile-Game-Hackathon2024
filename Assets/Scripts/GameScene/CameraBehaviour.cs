using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player;

    private void Update()
    {
        if (_player.transform.position.x > 5f && _player.transform.position.x < 265f)
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
