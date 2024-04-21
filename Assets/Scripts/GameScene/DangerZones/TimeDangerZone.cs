using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeDangerZone : DangerZoneController
{
    private bool _isCoroutineActive = false;

    private float _dangerActiveTime;

    private Collider2D _collider;

    private void Awake()
    {
        _dangerActiveTime = Random.Range(3, 7);
        _collider = GetComponent<Collider2D>();
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

        //Debug.Log("DangerZone UNactive");

        yield return new WaitForSeconds(_dangerActiveTime);

        _isDangerZoneActive = true;

        _collider.enabled = true;
        
        //Debug.Log("DangerZone active");

        yield return new WaitForSeconds(_dangerActiveTime);

        _isCoroutineActive = false;
    }
}
