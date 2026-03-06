using UnityEngine;

public class PelletManager : MonoBehaviour
{
    [SerializeField] private GameObject pelletPrefab;
    [SerializeField] private int pelletCount = 100;
    [SerializeField] private float mapWidth = 20f;
    [SerializeField] private float mapHeight = 20f;
    [SerializeField] private float gridSize = 0.5f;

    private int pelletsEaten = 0;
    public int PelletsRemaining { get; private set; }

    private void Start()
    {
        GeneratePellets();
    }

    private void GeneratePellets()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            float x = Random.Range(-mapWidth / 2, mapWidth / 2);
            float y = Random.Range(-mapHeight / 2, mapHeight / 2);
            
            x = Mathf.Round(x / gridSize) * gridSize;
            y = Mathf.Round(y / gridSize) * gridSize;

            Vector3 spawnPos = new Vector3(x, y, 0);
            GameObject pellet = Instantiate(pelletPrefab, spawnPos, Quaternion.identity, transform);
            pellet.tag = "Pellet";
        }

        PelletsRemaining = pelletCount;
    }

    public void EatPellet()
    {
        pelletsEaten++;
        PelletsRemaining--;

        if (PelletsRemaining <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("Vous avez gagne! Tous les pellets ont ete manges!");
        Time.timeScale = 0f;
    }
}
