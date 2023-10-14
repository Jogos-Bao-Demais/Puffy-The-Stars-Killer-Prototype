using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public partial class PuffyTheStarsKiller : MonoBehaviour, IDamageable
{
    [Header("References")]

    [Header("Stats")]
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _friction = .2f;

    [Header("Dash")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashDrag;
    [SerializeField] private float _dashDuration;

    [Header("Debug")]
    [SerializeField] private bool _shouldDie = false;

    private MainInputActions _inputActions;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementVector = Vector2.zero;
    private Vector2 _dashDirection = Vector2.zero;

    private bool _isDashing;
    private float _currentHealth;

    internal float _lookAngle;

    private void Awake()
    {
        _inputActions =  new MainInputActions();
        _inputActions.Player.Enable();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_currentHealth <= 0f) {
            Die();
        }

        _movementVector = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _rigidbody.velocity = _movementVector.x != 0  
            ? _movementVector.x * _moveSpeed * Time.fixedDeltaTime * Vector2.right + _rigidbody.velocity.y * Vector2.up 
            : new Vector2(Mathf.Lerp(_rigidbody.velocity.x, 0f, (_friction - 4f) * Time.fixedDeltaTime), _rigidbody.velocity.y);
        
        _rigidbody.velocity = _movementVector.y != 0  
            ? _rigidbody.velocity.x * Vector2.right + _movementVector.y * _moveSpeed * Time.fixedDeltaTime * Vector2.up 
            : new Vector2(_rigidbody.velocity.x, Mathf.Lerp(_rigidbody.velocity.y, 0f, (_friction - 4f) * Time.fixedDeltaTime));
    }

    private void Die()
    {
#if UNITY_EDITOR
        if (_shouldDie) {
            Debug.Log("Puffy The Stars Killer Died");

            return;
        }
#endif

        Debug.Log("Puffy The Stars Killer Died");
    }

    public void TakeDemage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0) {
            Die();

            return;
        }
    }
}
