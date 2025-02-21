using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // ��Ǩ�ͺ��������� GameScene �١����� Build Settings
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("isLoading", 1); // �ѹ�֡���������� Game.cs ��Ŵ������
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll(); // ź������૿������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ��Ŵ�չ����
    }

    public void QuitGame()
    {
        Application.Quit(); // �͡�ҡ�� (���麹 Build ��ԧ)
        Debug.Log("Game is exiting..."); // Debug ��ٺ� Unity Editor
    }
}
