using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // ใส่ชื่อ Scene เกมของคุณให้ตรงกับใน Build Settings
    public string gameSceneName = "GameScene";

    // เรียกจากปุ่ม Start
    public void StartGame()
    {
        SceneManager.LoadScene("Map1");
    }

    // เรียกจากปุ่ม Exit
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
