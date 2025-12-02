using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortal : MonoBehaviour
{
    [Header("Scene ปลายทาง")]
    public string targetSceneName = "Map2";

    [Header("ตัวละครผู้เล่นต้องมี Tag = Player")]
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Warp to scene: " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
