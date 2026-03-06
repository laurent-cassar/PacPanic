using UnityEngine;

public class PacmanController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 0.5f;
    
    private Vector2 direction = Vector2.right;
    private Vector2 nextDirection = Vector2.right;
    private float moveTimer = 0f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        Move();
        UpdateAnimation();
    }

    private void HandleInput()
    {
        // Clavier legacy: flèches et WASD
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            nextDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            nextDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            nextDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            nextDirection = Vector2.right;
    }

    private void Move()
    {
        moveTimer += Time.deltaTime;
        float moveInterval = gridSize / moveSpeed;

        if (moveTimer >= moveInterval)
        {
            moveTimer = 0f;

            if (CanMove(nextDirection))
                direction = nextDirection;

            Vector3 newPos = transform.position + (Vector3)direction * gridSize;
            transform.position = newPos;
        }
    }

    private bool CanMove(Vector2 moveDirection)
    {
        Vector3 checkPos = transform.position + (Vector3)moveDirection * gridSize;
        Collider2D hit = Physics2D.OverlapCircle(checkPos, 0.1f);
        return hit == null || hit.CompareTag("Pellet");
    }

    private void UpdateAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("DirX", direction.x);
            animator.SetFloat("DirY", direction.y);
        }
    }
}
