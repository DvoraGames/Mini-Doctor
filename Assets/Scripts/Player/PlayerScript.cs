using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Dependências")]

    [SerializeField] private DashBTNScript dashBTNScript;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 input;

    [Header("Configs")]
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;

    [Header("Infos")]
    public Vector2 direction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        direction = new(input.x, input.y);
    }

    public void Move()
    {
        rb.velocity = direction * speed;

        if (DashBTNScript.isDashing)
        {
            rb.velocity = direction.normalized * dashSpeed;
        }
    }

    public void Dash()
    {
        if (direction.magnitude > 0)
        {
            StartCoroutine(dashBTNScript.DashTimer());
        }
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    public void OnDash(InputValue value)
    {
        if (value.isPressed && DashBTNScript.canDash)
        {
            Dash();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BloodCell(Clone)")
        {
            gameObject.GetComponent<LifeManager>().lifes--;
        }
    }
}
