using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // รับ Input แนวตั้งแนวนอน
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // เคลื่อนที่ในโลก 2D
        rb.MovePosition(rb.position + input.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}