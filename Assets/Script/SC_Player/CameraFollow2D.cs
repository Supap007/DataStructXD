using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;      // ตัวที่กล้องจะตาม (ผู้เล่น)
    public float smoothSpeed = 5f; // ความเนียนในการตาม

    void LateUpdate()
    {
        if (target == null) return;

        // เอาตำแหน่งผู้เล่นมา แต่ใช้ค่า z ของกล้องเดิม
        Vector3 targetPosition = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        // เลื่อนกล้องแบบเนียน ๆ (ถ้าอยากให้ตามแบบเป๊ะ ๆ ใช้ = ได้เลย)
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed = Time.deltaTime
        );
    }
}
