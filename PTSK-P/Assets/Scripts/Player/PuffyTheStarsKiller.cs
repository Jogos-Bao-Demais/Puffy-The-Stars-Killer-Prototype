using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public partial class PuffyTheStarsKiller : MonoBehaviour, IDamageable, IIntangible
{
    [Header("References")]
    [SerializeField] private InputManager _playerInputs;

    [Header("Stats")]
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _friction = .2f;

    [Header("Dash")]
    [SerializeField] private float _dashSpeed = 40f;
    [SerializeField] private float _dashDrag = .3f;
    [SerializeField] private float _dashDuration = .1f;

    [Header("Debug")]
    [SerializeField] private bool _shouldDie = false;

    public bool IsIntangible { get => _isIntangible; }

    private Rigidbody2D _rigidbody = null;

    private bool _isIntangible = false;
    private bool _isDashing = false;
    private bool _canMove = true;

    private float _currentHealth = 0f;

    internal float _lookAngle = 0f;

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
        _isIntangible = true;

        await Task.Delay((int) (_dashDuration * 1000));

        _rigidbody.drag = 0f;
        _isDashing = false;
        _canMove = true;
        _isIntangible = false;
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
