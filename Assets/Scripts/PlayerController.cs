using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 30f;
    public float smoothSpeed = 10f;
    public LayerMask platformLayer;
    public float groundCheckDistance = 0.1f;

    private Rigidbody2D rb;
    private float screenHalfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
#if UNITY_EDITOR
        float tilt = Input.GetAxis("Horizontal");
#else
        float tilt = Input.acceleration.x;
#endif

        float targetVelocity = tilt * moveSpeed;
        float smooth = Mathf.Lerp(rb.linearVelocity.x, targetVelocity, Time.deltaTime * smoothSpeed);

        rb.linearVelocity = new Vector2(smooth, rb.linearVelocity.y);

        // Teletransporte lateral
        if (transform.position.x > screenHalfWidth)
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);

        if (transform.position.x < -screenHalfWidth)
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            // Solo salta si está tocando por abajo
            if (rb.linearVelocity.y <= 0 && transform.position.y > collision.transform.position.y)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
    bool IsGrounded()
    {
        // Lanzamos un raycast hacia abajo desde el centro del Player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, platformLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        // Para visualizar el raycast en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
