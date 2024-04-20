using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairEngineController : MonoBehaviour
{
    [SerializeField]
    protected LayerMask _playerMask;

    private PlayerController _playerController;

    private bool _isRepairing = false;

    private bool _isCanRepair = false;

    private float _repairTime = 3f;

    private IEnumerator RepairEngineCoroutine()
    {
        if (_isRepairing)
        {
            yield break;
        }

        _isRepairing = true;

        while (_isCanRepair)
        {
            yield return new WaitForSeconds(_repairTime);
            Repair();
        }

        _isRepairing = false;
    }

    private void Repair()
    {
        StartCoroutine(RepairEngineCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            int collisionLayer = collision.gameObject.layer;

            if (_playerMask == (1 << collisionLayer))
            {
                _isCanRepair = true;
                
                if (_playerController == null)
                    _playerController = FindObjectOfType<PlayerController>();

                if (_playerController != null)
                    _playerController.OnRepair.AddListener(Repair);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            int collisionLayer = collision.gameObject.layer;

            if (_playerMask == (1 << collisionLayer))
            {
                _isCanRepair = false;

                if (_playerController != null)
                    _playerController.OnRepair.RemoveListener(Repair);
            }
        }
    }
}
