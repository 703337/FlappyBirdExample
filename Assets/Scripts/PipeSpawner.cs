using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject pipePrefab;

    [SerializeField] float spawnCooldown;
    float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.HasGameStarted() == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                SpawnPipe();
            }
        }
    }

    void SpawnPipe()
    {
        currentTime = spawnCooldown;
        Instantiate(pipePrefab, transform);
    }
}
