using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private MoveDirection _moveDirection;

    private Rigidbody2D _rb;

    private float _speed;

    private bool _isCanMove = true;

    private bool _isJumping = true;

    public float PlayerSpeed { get => _speed;  private set => _speed = value; }
    public bool IsJumping { get => _isJumping;  private set => _isJumping = value; }
    public bool IsCanMove { get => _isCanMove; set => _isCanMove = value; }

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody2D rb))
        {
            _rb = rb;
        }
        else
        {
            new NullReferenceException("Check Player RigidBody!");
        }

    }

    private void Update()
    {
        if (_moveDirection != MoveDirection.None && _isCanMove)
        {
            switch (_moveDirection)
            {
                case MoveDirection.Left:
                    MovePlayer(-1);
                    break;
                
                case MoveDirection.Right:
                    MovePlayer(1);
                    break;

                default:
                    MovePlayer(0);
                    break;
            }
        }
    }

    private void MovePlayer(int moveDir)
    {
        if (moveDir != 0)
            transform.Translate(0, moveDir * _speed * Time.deltaTime, 0);
    }
}
