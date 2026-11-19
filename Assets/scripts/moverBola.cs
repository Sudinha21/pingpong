using UnityEngine;

public class moverBola : MonoBehaviour
{

    public float initialSpeed = 8f;
    public float maxSpeed = 20f;
    public float speedMultiplier = 1.1f;

    private float currentSpeed;
    private Rigidbody2D rb;
    private Vector2 lastSpeed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = initialSpeed;

        Vector2 startDirection = new Vector2(1f,0.3f).normalized;
        rb.linearVelocity = startDirection * currentSpeed; 
    }

    private void FixedUpdate()
    {
        lastSpeed = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player")) 
        {
            currentSpeed *= speedMultiplier;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
