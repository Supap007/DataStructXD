using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathTrap : MonoBehaviour
{
    public GameObject deathUI;
    public GameObject restartButton;

    // ชนแบบ Collision (ไม่ใช้ Trigger เพื่อให้ง่าย)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("DeathTrap HIT: " + collision.collider.name);

        if (!collision.collider.CompareTag("Player"))
            return;

        if (deathUI != null)
            deathUI.SetActive(true);

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
