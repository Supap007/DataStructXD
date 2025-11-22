using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform player;        // ลาก Player มาใส่
    [HideInInspector]
    public Vector3 spawnPoint;      // จุดเกิดล่าสุด

    void Start()
    {
        if (player != null)
        {
            spawnPoint = player.position;
            Debug.Log("Start spawn at: " + spawnPoint);
        }
        else
        {
            Debug.LogWarning("SpawnManager: player is NOT assigned!");
        }
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        spawnPoint = newPoint;
        Debug.Log("Checkpoint set to: " + spawnPoint);
    }

    public void Respawn()
    {
        if (player == null)
        {
            Debug.LogWarning("SpawnManager: player is NULL in Respawn");
            return;
        }

        player.position = spawnPoint;

        var rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;

        Debug.Log("Respawn player at: " + spawnPoint);
    }
}
