using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] float jumpForce;
    Rigidbody2D rb;
    Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.HasGameStarted())
        {
            Jump();
        }
    }

    public void StartGame()
    {
        transform.position = startPosition;
        rb.gravityScale = 1;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    void Dead()
    {
        Debug.Log("Dead");
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero; //Vector2.zero is the same as Vector2(0,0)
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            Dead();
        }
        if (collision.CompareTag("Score"))
        {
            gameManager.PointScored();
        }
    }
}
