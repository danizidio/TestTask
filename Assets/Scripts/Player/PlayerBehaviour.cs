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
    public EquipmentAttributes[] EquipAttribute { get { return _equipAttribute; } }

    [SerializeField] SpriteRenderer[] _lightArmorPieces, _heavyArmorPieces;

    int _currentLife;
    public int CurrentLife { get { return _currentLife; } set { _currentLife = value; } }

    Rigidbody2D rb;

    float _moveSpeed;

    private float _moveX;
    private float _moveY;

    private bool _isRunning;

    bool _canMove;

    SaveLoad s;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CharCreationBehaviour.instance.LoadCustomCharacter();

        _canMove = true;

        _currentLife = PlayerAttribute.HealthPoints;
    }

    void LateUpdate()
    {
        if (!_isRunning)
        {
            _isRunning = false;
            _moveSpeed = PlayerAttribute.MoveSpeed;
        }

        rb.velocity = new Vector2(_moveX * _moveSpeed, _moveY * _moveSpeed);
    }

    #region - InputManager Buttons
    public void OnMove(InputAction.CallbackContext context)
    {
        if(_canMove)
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

    public bool CanMove(bool b)
    {
        return _canMove;
    }

    private void OnDisable()
    {
        OnActing = null;
    }
}
