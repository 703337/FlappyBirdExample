using UnityEngine;

public class EnviroSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject enviroPrefab;

    [SerializeField] float spawnCooldown;
    float currentTime;

    // Update is called once per frame
    void Update()
    {
        if(gameManager.HasGameStarted() == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                SpawnEnviro();
            }
        }
    }

    public void ResetSpawner()
    {
        currentTime = 0;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void SpawnEnviro()
    {
        currentTime = spawnCooldown;
        Instantiate(enviroPrefab, transform);
    }
}
