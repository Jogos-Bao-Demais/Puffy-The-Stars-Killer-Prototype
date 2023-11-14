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

    [Header("Movement")]
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _friction = .2f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _lowJumpMultiplier = 2;

    [Header("Dash")]
    [SerializeField] private float _dashSpeed = 40f;
    [SerializeField] private float _dashDrag = .3f;
    [SerializeField] private float _dashDuration = .1f;

    [Header("Debug")]
    [SerializeField] private bool _shouldDie = false;

    public bool IsIntangible { get => _isIntangible; }

    private Rigidbody2D _rigidbody = null;
    private Collision _col = null;

    private bool _isIntangible = false;
    private bool _isDashing = false;
    private bool _canMove = true;
    private bool _avoidDoubleJump = false;

    private float _currentHealth = 0f;

    private int _canJump = 0;
    private int _lookSide = 0;

    internal float _lookAngle = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collision>();
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

    private async void FixedUpdate()
    {
        _canJump--;
        
        if (_canMove) {
            Movement();
        }

        JumpBuffer();

        if (_col.IsGrounded)
        {
            _canJump = 8;
        }

        if (_playerInputs.JumpTap)
        {
            if (_canJump > 0)
            {
                await Jump();
            }
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
    }

    private async Task Jump()
    {
        if (_avoidDoubleJump) return;

        print("jump");

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        _canJump = 0;

        await JumpAwait(.3f);
    }

    /// <summary>
    /// if falling, add fallMultiplier
    /// if jumping and not holding spacebar or walljumping, increase gravity to peform a small jump
    /// if jumping and holding spacebar, perform a full jump
    /// </summary>
    private void JumpBuffer()
    {
        if (_rigidbody.velocity.y < 0) {
            _rigidbody.velocity += (_fallMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (_rigidbody.velocity.y > 0 && !_playerInputs.JumpHold) {
            _rigidbody.velocity += (_lowJumpMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector2.up;
        }
    }

    private async void Dash()
    {
        var dir = new Vector2(_playerInputs.MoveDir.x, _playerInputs.MoveDir.y);

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.velocity += dir.normalized * _dashSpeed;

        await DashAwait();
    }

    public async Task JumpAwait(float duration)
    {
        _avoidDoubleJump = true;

        await Task.Delay((int) (duration * 1000));

        _avoidDoubleJump = false;
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
