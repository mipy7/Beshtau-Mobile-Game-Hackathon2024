using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private PlayerController _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            int collisionLayer = collision.gameObject.layer;

            if (_groundLayer == (1 << collisionLayer))
            {
                _player.IsJumping = false;
            }
        }
    }
}
