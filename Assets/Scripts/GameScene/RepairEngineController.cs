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

    private bool _hasBeenRepaired = false;

    private IEnumerator RepairEngineCoroutine()
    {
        if (_isRepairing)
        {
            yield break;
        }

        _isRepairing = true;

        _playerController.IsCanMove = false;

        while (_isCanRepair)
        {
            _isCanRepair = false;
            yield return new WaitForSeconds(_repairTime);
            Repair();
        }
        
        _hasBeenRepaired = true;

        GameController gameController = FindObjectOfType<GameController>();

        gameController.IncreaseRepairedEnginesCount();

        Debug.Log("Repair Finish");

        _playerController.IsCanMove = true;

        _isRepairing = false;
    }

    private void Repair()
    {
        Debug.Log("is repair");

        if (!_hasBeenRepaired)
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
                    _playerController = collision.gameObject.transform.GetComponent<PlayerController>();

                if (_playerController != null)
                    _playerController.OnRepair.AddListener(Repair);

                Debug.Log("OnRepair");
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
