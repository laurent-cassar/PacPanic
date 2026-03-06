using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform pacmanSpawn;
    [SerializeField] private Transform[] ghostSpawns;
    [SerializeField] private GameObject pacmanPrefab;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private PelletManager pelletManager;

    private int lives = 3;
    private int score = 0;
    private GameObject pacman;
    private GameObject[] ghosts;

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        SpawnPacman();
        SpawnGhosts();
    }

    private void SpawnPacman()
    {
        pacman = Instantiate(pacmanPrefab, pacmanSpawn.position, Quaternion.identity);
        pacman.tag = "Player";
    }

    private void SpawnGhosts()
    {
        ghosts = new GameObject[ghostSpawns.Length];
        for (int i = 0; i < ghostSpawns.Length; i++)
        {
            GameObject ghost = Instantiate(ghostPrefab, ghostSpawns[i].position, Quaternion.identity);
            ghost.tag = "Ghost";
            
            GhostAI ghostAI = ghost.GetComponent<GhostAI>();
            if (ghostAI != null)
                ghostAI.pacmanTarget = pacman.transform;

            ghosts[i] = ghost;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Destroy(pacman);
            SpawnPacman();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! Score final: " + score);
        Time.timeScale = 0f;
    }

    public int Lives => lives;
    public int Score => score;
}
