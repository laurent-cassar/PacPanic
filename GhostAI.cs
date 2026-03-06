using UnityEngine;

public class GhostAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float gridSize = 0.5f;
    [SerializeField] private Transform pacmanTarget;
    [SerializeField] private int chaseDistance = 8;
    
    private Vector2 direction = Vector2.left;
    private float moveTimer = 0f;
    private bool isChasing = false;

    private void Update()
    {
        UpdateAI();
        Move();
    }

    private void UpdateAI()
    {
        if (pacmanTarget == null) return;

        float distance = Vector2.Distance(transform.position, pacmanTarget.position);
        isChasing = distance < chaseDistance;

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            RandomWalk();
        }
    }

    private void ChasePlayer()
    {
        Vector2 directionToPacman = (pacmanTarget.position - transform.position).normalized;
        
        if (Mathf.Abs(directionToPacman.x) > Mathf.Abs(directionToPacman.y))
            direction = directionToPacman.x > 0 ? Vector2.right : Vector2.left;
        else
            direction = directionToPacman.y > 0 ? Vector2.up : Vector2.down;
    }

    private void RandomWalk()
    {
        if (Random.value < 0.02f)
        {
            int randomDir = Random.Range(0, 4);
            direction = randomDir switch
            {
                0 => Vector2.up,
                1 => Vector2.down,
                2 => Vector2.left,
                _ => Vector2.right
            };
        }
    }

    private void Move()
    {
        moveTimer += Time.deltaTime;
        float moveInterval = gridSize / moveSpeed;

        if (moveTimer >= moveInterval)
        {
            moveTimer = 0f;
            Vector3 newPos = transform.position + (Vector3)direction * gridSize;
            
            if (CanMove(newPos))
                transform.position = newPos;
        }
    }

    private bool CanMove(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, 0.1f);
        return hit == null || hit.CompareTag("Pellet") || hit.CompareTag("Player");
    }
}
