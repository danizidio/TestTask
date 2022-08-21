using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public event Action OnActing;
    public event Action OnPausing;

    [SerializeField] private PlayerAttributes _playerAttribute;

    public PlayerAttributes PlayerAttribute { get { return _playerAttribute; } }

    int _currentLife;
    public int CurrentLife { get { return _currentLife; } set { _currentLife = value; } }

    Rigidbody2D rb;

    float moveSpeed;

    private float moveX;
    private float moveY;

    private bool isRunning;

    private void Start()
    {
        _currentLife = PlayerAttribute.HealthPoints;
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (!isRunning)
        {
            isRunning = false;
            moveSpeed = PlayerAttribute.MoveSpeed;
        }

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    #region - InputManager Buttons
    public void OnMove(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
        moveY = context.ReadValue<Vector2>().y;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();

        if (isRunning)
        {
            moveSpeed = PlayerAttribute.MoveSpeed * PlayerAttribute.MoveSpeed;
        }
        else
        {
            moveSpeed = PlayerAttribute.MoveSpeed;
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


    private void OnDisable()
    {
        OnActing = null;
    }
}
