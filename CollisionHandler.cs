using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private PacmanController pacmanController;

    private void Start()
    {
        pacmanController = GetComponent<PacmanController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            gameManager.AddScore(10);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Ghost"))
        {
            gameManager.LoseLife();
        }
    }
}
