using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairEngineController : MonoBehaviour
{
    [SerializeField]
    protected LayerMask _playerMask;

    private PlayerController _playerController;

    [SerializeField]
    private SpriteRenderer _oldSpriteRenderer;

    [SerializeField]
    private SpriteRenderer _repairKeySpriteRenderer;

    [SerializeField]
    private SpriteRenderer _textSpriteRenderer;

    [SerializeField]
    private SpriteRenderer _newSpriteRenderer;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Sprite _sprite;

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

        _animator.SetBool("IsRepair", true);

        while (_isCanRepair)
        {
            _isCanRepair = false;
            yield return new WaitForSeconds(_repairTime);
            Repair();
        }

        _animator.SetBool("IsRepair", true);

        _newSpriteRenderer.sprite = _sprite;

        _oldSpriteRenderer.sprite = null;

        _repairKeySpriteRenderer.sprite = null;

        _textSpriteRenderer.sprite = null;

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
