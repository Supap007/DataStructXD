using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;
    private Vector2 input;

    // ให้ PlayerInteraction ใช้อ่านทิศทางล่าสุด
    public Vector2 LastMoveDirection { get; private set; } = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // ถ้ามีการกดปุ่มเดิน ให้จำทิศไว้
        if (input.sqrMagnitude > 0.01f)
        {
            LastMoveDirection = input.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }
}
