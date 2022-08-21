using System;
using UnityEngine;
using UnityEngine.InputSystem;
using SaveLoadPlayerPrefs;

public class PlayerBehaviour : MonoBehaviour
{
    public event Action OnActing;
    public event Action OnPausing;

    [SerializeField] PlayerAttributes _playerAttribute;

    public PlayerAttributes PlayerAttribute { get { return _playerAttribute; } }

    [SerializeField] EquipmentAttributes[] _equipAttribute;

    [SerializeField] GameObject[] _weapons;
    public EquipmentAttributes[] EquipAttribute { get { return _equipAttribute; } }

    [SerializeField] SpriteRenderer[] _lightArmorPieces, _heavyArmorPieces;

    int _currentLife;
    public int CurrentLife { get { return _currentLife; } set { _currentLife = value; } }

    Rigidbody2D rb;

    float _moveSpeed;

    private float _moveX;
    private float _moveY;

    private bool _isRunning;

    [SerializeField] bool _canMove;
    public bool canMove { get { return _canMove; } }

    SaveLoad s;

    Animator _anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CharCreationBehaviour.instance.LoadCustomCharacter();

        _canMove = true;

        _currentLife = PlayerAttribute.HealthPoints;

        _anim = GetComponentInChildren<Animator>();
    }

    void LateUpdate()
    {
        if (OnActing == null)
        {
            OnActing = Attacking;
        }

        if (!_isRunning)
        {
            _isRunning = false;
            _moveSpeed = PlayerAttribute.MoveSpeed;
        }

        if (_moveX == 0 && _moveY == 0)
        {
            _anim.SetBool("WALK", false);
        }

        if (_canMove == false)
        {
            _moveX = 0;
            _moveY = 0;
        }

        rb.velocity = new Vector2(_moveX * _moveSpeed, _moveY * _moveSpeed);
    }

    #region - InputManager Buttons
    public void OnMove(InputAction.CallbackContext context)
    {
        if (_moveX == 1)
        {
            _anim.SetBool("WALK", true);
            transform.localScale = new Vector3(1, 1, 0);
        }
        if (_moveX == -1)
        {
            _anim.SetBool("WALK", true);
            transform.localScale = new Vector3(-1, 1, 0);
        }

        if (_canMove)
        {


            _moveX = context.ReadValue<Vector2>().x;
            _moveY = context.ReadValue<Vector2>().y;


        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        _isRunning = context.ReadValueAsButton();

        if (_isRunning)
        {
            _moveSpeed = PlayerAttribute.MoveSpeed * PlayerAttribute.MoveSpeed;
        }
        else
        {
            _moveSpeed = PlayerAttribute.MoveSpeed;
        }
    }

    public void OnInteracting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnActing?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnPausing?.Invoke();
        }
    }
    #endregion

    void Attacking()
    {
        _anim.SetTrigger("ATTACK");
    }

    public bool CanMove(bool b)
    {
        return _canMove = b;
    }

    private void OnDisable()
    {
        OnActing = null;
    }
}
