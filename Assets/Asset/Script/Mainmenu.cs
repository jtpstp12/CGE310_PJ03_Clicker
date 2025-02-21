using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // ตรวจสอบให้แน่ใจว่า GameScene ถูกเพิ่มใน Build Settings
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("isLoading", 1); // บันทึกค่าเพื่อให้ Game.cs โหลดข้อมูล
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll(); // ลบข้อมูลเซฟทั้งหมด
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดซีนใหม่
    }

    public void QuitGame()
    {
        Application.Quit(); // ออกจากเกม (ใช้ได้บน Build จริง)
        Debug.Log("Game is exiting..."); // Debug ใช้ดูบน Unity Editor
    }
}
