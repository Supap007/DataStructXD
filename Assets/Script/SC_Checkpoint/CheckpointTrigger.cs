using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public SpawnManager spawnManager;   // ลาก GameObject ที่มี SpawnManager
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        if (spawnManager != null)
        {
            spawnManager.SetCheckpoint(transform.position);
        }
        else
        {
            Debug.LogWarning("CheckpointTrigger: spawnManager is NULL!");
        }
    }
}
