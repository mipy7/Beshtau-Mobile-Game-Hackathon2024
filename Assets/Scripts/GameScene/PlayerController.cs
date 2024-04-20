using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private MoveDirection _moveDirection = MoveDirection.None;

    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 100f;

    [SerializeField] private float _jumpDuration = 10f;

    private int _health = 3;

    private int _maxHealth = 3;

    private int _score = 0;

    private bool _isShielBonusdActive = false;

    private bool _isScoreBonusActive = false;

    public bool IsShieldBonusActive { get => _isShielBonusdActive; set => _isShielBonusdActive = value; }

    public bool IsScoreBonusActive { get => _isScoreBonusActive; set => _isScoreBonusActive = value; }

    private bool _isCanMove = true;

    private bool _isJumping = false;

    public float PlayerSpeed { get => _speed; private set => _speed = value; }
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public bool IsCanMove { get => _isCanMove; set => _isCanMove = value; }

    [HideInInspector]
    public UnityEvent OnHealthBonus = new UnityEvent();

    [HideInInspector]
    public UnityEvent OnShieldBonus = new UnityEvent();

    [HideInInspector]
    public UnityEvent OnScoreBonus = new UnityEvent();

    [HideInInspector]
    public UnityEvent OnRepair = new UnityEvent();

    [HideInInspector]
    public UnityEvent OnFinish = new UnityEvent();

    [HideInInspector]
    public UnityEvent<int, int> OnHealthChange = new UnityEvent<int, int>();

    [HideInInspector]
    public UnityEvent<int> OnScoreChange = new UnityEvent<int>();

    [SerializeField]
    [Tooltip(" 0 -> Health bonus \n 1 -> Shield bonus \n 2 -> Score bonus \n 3 -> Finish zone \n 4 -> Heal \n 5 -> Point ")]
    private List<LayerMask> _activityLayers = new List<LayerMask>();

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

    private void Start()
    {
        List<DangerZoneController> dangerZoneControllers = new List<DangerZoneController>();
        dangerZoneControllers = FindObjectsOfType<DangerZoneController>().ToList();
        foreach (var zone in dangerZoneControllers)
        {
            zone.OnDangerZone.AddListener(DecreaseHealth);
        }
    }

    private void FixedUpdate()
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
                    break;
            }
        }
    }

    private void MovePlayer(int moveDir)
    {
        _rb.velocity = new Vector2(moveDir * Time.deltaTime * _speed, _rb.velocity.y);
    }

    public void Jump()
    {
        if (_isCanMove && !_isJumping)
        {
            _rb.AddForce(Vector2.up * _jumpDuration, ForceMode2D.Impulse);
            _isJumping = true;
        }
    }

    public void ChangeMoveSide(int moveDirection)
    {
        _moveDirection = (MoveDirection)moveDirection;
        _rb.velocity *= Vector2.up;
    }

    private void DecreaseHealth()
    {
        if (!_isShielBonusdActive)
        {
            _health--;
            OnHealthChange.Invoke(_health, _maxHealth);
            Debug.Log("Damage");
        }
    }

    private void IncreaseHealth()
    {
        _health++;
        OnHealthChange.Invoke(_health, _maxHealth);
        Debug.Log("Heal");
    }

    public void MaxHealthIncrease()
    {
        _health++;
        _maxHealth++;
        OnHealthChange.Invoke(_health, _maxHealth);
    }

    private void IncreasePoints()
    {
        if (!_isScoreBonusActive)
            _score++;
        else
            _score += 2;

        OnScoreChange.Invoke(_score);
    }

    public void RepairEngine()
    {
        OnRepair.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            int collisionLayer = collision.gameObject.layer;

            // Health bonus
            if (_activityLayers[0] == (1 << collisionLayer))
            {
                OnHealthBonus.Invoke();
                Destroy(collision.gameObject);
            }
            // Shield bonus
            else if (_activityLayers[1] == (1 << collisionLayer))
            {
                OnShieldBonus.Invoke();
                Destroy(collision.gameObject);
            }
            // Score bonus
            else if (_activityLayers[2] == (1 << collisionLayer))
            {
                OnScoreBonus.Invoke();
                Destroy(collision.gameObject);
            }
            //// Engine repair
            //else if (_activityLayers[3] == (1 << collisionLayer))
            //{
            //    OnRepair.Invoke(true);
            //}
            // Finish
            else if (_activityLayers[3] == (1 << collisionLayer))
            {
                OnFinish.Invoke();
            }
            // Heal
            else if (_activityLayers[4] == (1 << collisionLayer))
            {
                IncreaseHealth();
                Destroy(collision.gameObject);
            }
            // Point
            else if (_activityLayers[5] == (1 << collisionLayer))
            {
                IncreasePoints();
                Destroy(collision.gameObject);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision != null)
    //    {
    //        int collisionLayer = collision.gameObject.layer;

    //        Engine repair left
    //        if (_activityLayers[3] == (1 << collisionLayer))
    //        {
    //            OnRepair.Invoke(false);
    //        }
    //    }
    //}
}