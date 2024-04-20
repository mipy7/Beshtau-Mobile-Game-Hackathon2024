using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField]
    protected LayerMask _playerMask;

    protected PlayerController _player;

    protected bool _isDangerZoneActive = true;

    [HideInInspector]
    public UnityEvent OnDangerZone = new UnityEvent();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            int collisionLayer = collision.gameObject.layer;

            if (_playerMask == (1 << collisionLayer))
            {
                DangerZoneDamage();
            }
        }
    }

    protected void DangerZoneDamage()
    {
        if (_isDangerZoneActive)
        {
            Debug.Log("Damage -");
            OnDangerZone.Invoke();
        }
        else
        {

        }
    }
}
