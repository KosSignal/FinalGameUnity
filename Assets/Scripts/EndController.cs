using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    void Start() {
        PlayerPrefs.SetInt("PrevScene", SceneManager.GetActiveScene().buildIndex);
    }

    public void Credits() {
        SceneManager.LoadScene(7);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }
}
