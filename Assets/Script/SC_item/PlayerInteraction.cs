using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(PlayerEquipment))]
public class PlayerInteraction : MonoBehaviour
{
    [Header("Reference")]
    public TopDownMovement movement;
   // สคริปต์เดินของคุณ (ถ้าใช้ชื่ออื่นก็เปลี่ยน)
    public PlayerEquipment equipment;

    [Header("Interact Settings")]
    public float interactDistance = 1f;
    public LayerMask resourceLayer;     // เลเยอร์ของวัตถุที่ขุดได้

    [Header("UI Message")]
    public TMP_Text messageText;        // ข้อความ UI
    public float messageDuration = 1.5f;

    Coroutine messageRoutine;

    void Reset()
    {
        equipment = GetComponent<PlayerEquipment>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        if (movement == null)
        {
            Debug.LogWarning("PlayerInteraction: ยังไม่ได้อ้างอิง PlayerMovement2D");
            return;
        }

        // เอาทิศสุดท้ายที่เดินอยู่
        Vector2 dir = movement.LastMoveDirection;
        if (dir == Vector2.zero)
        {
            // ถ้าไม่เคยเดินเลยสมมติให้มองลง
            dir = Vector2.down;
        }

        Vector2 origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, dir.normalized, interactDistance, resourceLayer);

        Debug.DrawRay(origin, dir.normalized * interactDistance, Color.yellow, 0.5f);

        if (hit.collider != null)
        {
            var resource = hit.collider.GetComponent<InteractableResource>();
            if (resource != null)
            {
                bool ok = resource.TryHarvest(equipment.currentTool);
                if (ok)
                {
                    ShowMessage(resource.successMessage);
                }
                else
                {
                    ShowMessage(resource.failMessage);
                }
            }
        }
        else
        {
            // ไม่มีอะไรข้างหน้า
            ShowMessage("ไม่มีอะไรให้ขุดอยู่ตรงหน้า");
        }
    }

    void ShowMessage(string msg)
    {
        if (messageText == null) return;

        if (messageRoutine != null)
            StopCoroutine(messageRoutine);

        messageRoutine = StartCoroutine(MessageRoutine(msg));
    }

    IEnumerator MessageRoutine(string msg)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = msg;
        yield return new WaitForSeconds(messageDuration);
        messageText.gameObject.SetActive(false);
    }
}
