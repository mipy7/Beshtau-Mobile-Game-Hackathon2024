using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeDangerZone : DangerZoneController
{
    private bool _isCoroutineActive = false;

    private float _dangerActiveTime;

    private Collider2D _collider;

    private Animator _animator;

    private void Awake()
    {
        _dangerActiveTime = Random.Range(3, 4);
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(DangerZoneCoroutine());
    }

    private IEnumerator DangerZoneCoroutine()
    {

        if (_isCoroutineActive)
        {
            yield break;
        }

        _isCoroutineActive = true;

        _isDangerZoneActive = false;

        _collider.enabled = false;

        if (_animator != null )
            _animator.SetBool("IsActive", false);

        yield return new WaitForSeconds(_dangerActiveTime);

        _isDangerZoneActive = true;

        _collider.enabled = true;

        if (_animator != null)
            _animator.SetBool("IsActive", true);

        yield return new WaitForSeconds(_dangerActiveTime);

        _isCoroutineActive = false;
    }
}
