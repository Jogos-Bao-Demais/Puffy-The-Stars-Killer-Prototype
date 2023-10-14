using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PuffyTheStarsKiller : MonoBehaviour
{
    [Header("References")]

    [Header("Stats")]
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _friction = .2f;

    [Header("Dash")]

    private MainInputActions _inputActions;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementVector = Vector2.zero;
    private Vector2 _dashDirectin = Vector2.zero;

    private bool _isDashing;
    private float _currentHealth;

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

    private void FixedUpdate()
    {
        
    }
}
