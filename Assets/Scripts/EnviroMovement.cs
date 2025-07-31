using UnityEngine;

public class EnviroMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float randomOffset;
    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 newPos = transform.position; //Get Reference to the environment's original position
        newPos.y = Random.Range(-randomOffset, randomOffset);
        
        transform.position = newPos;
        gameManager = FindFirstObjectByType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.HasGameStarted())
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= -19)
            {
                Destroy(gameObject); //gameObject with a lowercase g is referring to itself
            }
        }
    }
}
