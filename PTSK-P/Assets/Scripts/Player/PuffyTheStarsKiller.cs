using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public partial class PuffyTheStarsKiller : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] private InputManager _playerInputs;

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

    private Rigidbody2D _rigidbody;

    private bool _isDashing;
    private bool _canMove;

    private float _currentHealth;

    internal float _lookAngle;

    private void Awake()
    {
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
    }

    private void FixedUpdate()
    {
        if (_canMove) {
            Movement();
        }

        if (_playerInputs.DashKey && !_isDashing) {
            if (_playerInputs.MoveDir.x != 0 || _playerInputs.MoveDir.y != 0) {
                Dash();
            }
        }
    }

    private void Movement()
    {
        _rigidbody.velocity = _playerInputs.MoveDir.x != 0  
            ? _playerInputs.MoveDir.x * _moveSpeed * Time.fixedDeltaTime * Vector2.right + _rigidbody.velocity.y * Vector2.up 
            : new Vector2(Mathf.Lerp(_rigidbody.velocity.x, 0f, (_friction - 4f) * Time.fixedDeltaTime), _rigidbody.velocity.y);
        
        _rigidbody.velocity = _playerInputs.MoveDir.y != 0  
            ? _rigidbody.velocity.x * Vector2.right + _playerInputs.MoveDir.y * _moveSpeed * Time.fixedDeltaTime * Vector2.up 
            : new Vector2(_rigidbody.velocity.x, Mathf.Lerp(_rigidbody.velocity.y, 0f, (_friction - 4f) * Time.fixedDeltaTime));
    }

    private async void Dash()
    {
        var dir = new Vector2(_playerInputs.MoveDir.x, _playerInputs.MoveDir.y);

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.velocity += dir.normalized * _dashSpeed;

        await DashAwait();
    }

    private async Task DashAwait()
    {
        _rigidbody.drag = _dashDrag;
        _isDashing = true;
        _canMove = false;

        await Task.Delay((int) (_dashDuration * 1000));

        _canMove = true;
        _isDashing = false;
        _rigidbody.drag = 0f;
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
