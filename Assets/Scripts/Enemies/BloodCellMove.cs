using UnityEngine;

public class BloodCellMove : MonoBehaviour
{
    [Header("Dependências")]
    private Rigidbody2D rb;

    [Header("Globulo Vermelho Config")]
    [SerializeField] private float speed;
    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;

    private float startY;

    private void Start()
    {
        speed = Random.Range(2, 5);
        frequency = Random.Range(1, 3);
        amplitude = Random.Range(1, 3);

        rb = GetComponent<Rigidbody2D>();

        startY = transform.position.y;
    }

    private void FixedUpdate()
    {
        float verticalMove = startY + amplitude * Mathf.Sin(frequency * Time.time);
        rb.velocity = new Vector2(-speed, verticalMove - transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Borders") || collision.gameObject.CompareTag("Enemies"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
        else if (collision.collider.CompareTag("EntityDestroyer"))
        {
            if (gameObject.name == "BloodCell(Clone)")
            {
                Destroy(gameObject);
            }
            else if (gameObject.name == "InfectedBloodCell(Clone)")
            {
                Destroy(gameObject);
                UIScript.score -= 10;
            }
        }
    }
}
