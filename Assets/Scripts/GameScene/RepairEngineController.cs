using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairEngineController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;

    private bool _isRepairing = false;

    private bool _isCanRepair = false;

    private float _repairTime = 3f;

    private void Awake()
    {
        _player.OnRepair.AddListener(OnRepair);
    }

    private void OnRepair(bool isRepair)
    {
        if (isRepair)
        {
            _isCanRepair = true;
        }
        else
        {
            _isCanRepair = false;
        }
    }

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

    }
}
