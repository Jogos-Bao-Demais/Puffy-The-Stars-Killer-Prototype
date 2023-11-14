using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask whatIsBlocks;

    [Header("Horizontal Collision")]
    [SerializeField] private Vector2 rightColOffset;
    [SerializeField] private Vector2 leftColOffset;

    [Range(0f, 1f)]
    [SerializeField] private float horizontalColRadius = .5f;

    [Header("Vertical Collision")]
    [SerializeField] private Vector2 bottomColSize;
    [SerializeField] private Vector2 bottomColOffset;

    [Space]

    public bool IsOnRightWall = false;
    public bool IsOnLeftWall = false;
    public bool IsOnWall = false;
    public bool IsGroundedEarly = false;

    public float BottomColYSize;

    public int WallSide;

    [Space]

    public bool IsGrounded = false;

    private void FixedUpdate()
    {
        IsOnRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightColOffset, horizontalColRadius, whatIsBlocks);
        IsOnLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftColOffset, horizontalColRadius, whatIsBlocks);

        IsOnWall = IsOnLeftWall || IsOnRightWall;
        WallSide = IsOnRightWall ? -1 : 1;

        IsGrounded = Physics2D.OverlapBox((Vector2)transform.position + bottomColOffset, bottomColSize, 0f, whatIsBlocks);
        IsGroundedEarly = Physics2D.OverlapBox((Vector2)transform.position + new Vector2(bottomColOffset.x, bottomColOffset.y - .12f), new Vector2(bottomColSize.x, bottomColSize.y + .2f), 0f, whatIsBlocks);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + rightColOffset, horizontalColRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftColOffset, horizontalColRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube((Vector2)transform.position + bottomColOffset, bottomColSize);
    }
}