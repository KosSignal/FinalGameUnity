using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        PlayerPrefs.SetInt("Lives", 5);
        SceneManager.LoadScene(1);
    }
}
