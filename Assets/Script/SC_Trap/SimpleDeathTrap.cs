using UnityEngine;
using System.Collections;
using TMPro;

public class SimpleDeathTrap : MonoBehaviour
{
    [Header("Reference")]
    public Transform player;                    // Player
    public SpawnManager spawnManager;           // SpawnManager
    public MonoBehaviour playerMovementScript;  // สคริปต์เดินของ Player

    [Header("UI")]
    public GameObject deathUI;                  // กล่อง DeadUI
    public TMP_Text deathText;                  // Text ใน DeadUI
    public GameObject restartButton;            // ปุ่ม Restart

    [Header("Settings")]
    public float triggerRadius = 0.5f;
    public bool randomLine = true;

    [Header("Death Lines")]
    [TextArea(2, 4)]
    public string[] deathLines;

    bool isDead = false;
    int lastIndex = -1;

    void Update()
    {
        if (isDead) return;
        if (player == null) return;

        float dist = Vector2.Distance(player.position, transform.position);
        if (dist <= triggerRadius)
        {
            OnPlayerDead();
        }
    }

    void OnPlayerDead()
    {
        isDead = true;
        Debug.Log("Trap hit, player die on: " + gameObject.name);

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        var rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        if (deathUI != null)
            deathUI.SetActive(true);

        if (deathText != null && deathLines != null && deathLines.Length > 0)
        {
            int index = 0;

            if (randomLine)
            {
                if (deathLines.Length == 1)
                    index = 0;
                else
                {
                    do
                    {
                        index = Random.Range(0, deathLines.Length);
                    } while (index == lastIndex);
                }
            }
            else
            {
                index = (lastIndex + 1) % deathLines.Length;
            }

            lastIndex = index;
            deathText.text = deathLines[index];
        }

        if (restartButton != null)
            restartButton.SetActive(false);

        StartCoroutine(ShowRestart());
    }

    IEnumerator ShowRestart()
    {
        yield return new WaitForSeconds(5f);

        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restart pressed");

        if (spawnManager != null)
        {
            spawnManager.Respawn();
        }
        else
        {
            Debug.LogWarning("SimpleDeathTrap: spawnManager is NULL!");
        }

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        if (deathUI != null)
            deathUI.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        isDead = false;
    }
}
