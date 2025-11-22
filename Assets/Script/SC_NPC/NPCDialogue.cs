using UnityEngine;
using TMPro;   // ต้องมีถ้าใช้ TextMeshPro

public class NPCDialogue : MonoBehaviour
{
    [Header("Reference")]
    public Transform player;            // ลาก Player มาวาง
    public GameObject dialogueUI;       // ลาก DialogueUI มาวาง
    public TMP_Text dialogueText;       // ลาก DialogueText มาวาง

    [Header("Dialogue")]
    [TextArea(2, 4)]
    public string[] lines;              // ประโยคสนทนาแต่ละบรรทัด

    [Header("Settings")]
    public float talkRange = 1.5f;      // ระยะที่คุยได้
    public KeyCode talkKey = KeyCode.E; // ปุ่มกดคุยsz

    int currentIndex = 0;
    bool isTalking = false;

    void Update()
    {
        if (player == null) return;

        // วัดระยะระหว่าง Player กับ NPC
        float dist = Vector2.Distance(player.position, transform.position);

        // ถ้าอยู่ในระยะคุย
        if (dist <= talkRange)
        {
            if (Input.GetKeyDown(talkKey))
            {
                if (!isTalking)
                {
                    StartDialogue();
                }
                else
                {
                    NextLine();
                }
            }
        }
        else
        {
            // เดินหนีออกจากระยะคุย ให้ปิดบทสนทนา
            if (isTalking)
                EndDialogue();
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        currentIndex = 0;

        if (dialogueUI != null)
            dialogueUI.SetActive(true);

        if (dialogueText != null && lines.Length > 0)
            dialogueText.text = lines[currentIndex];
    }

    void NextLine()
    {
        currentIndex++;

        if (currentIndex >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            if (dialogueText != null)
                dialogueText.text = lines[currentIndex];
        }
    }

    void EndDialogue()
    {
        isTalking = false;

        if (dialogueUI != null)
            dialogueUI.SetActive(false);
    }
}
