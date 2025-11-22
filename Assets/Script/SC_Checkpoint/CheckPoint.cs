using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform player;
    public SpawnManager spawnManager;
    public float radius = 0.8f;

    bool activated = false;

    void Update()
    {
        if (activated) return;
        if (player == null || spawnManager == null) return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (dist <= radius)
        {
            spawnManager.SetCheckpoint(transform.position);
            activated = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
