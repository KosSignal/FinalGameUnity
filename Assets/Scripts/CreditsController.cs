using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsController : MonoBehaviour
{
    private Image image;

    public GameObject title;
    public GameObject devCredits;
    public GameObject button;

    private Color32 textColor;

    void Awake() {
        image = GetComponent<Image>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { // Change Background Color
        ColorBlock cb = button.GetComponent<Button>().colors;
        if (PlayerPrefs.GetInt("PrevScene") == 6) { // You Lost
            image.color = new Color32(140, 0, 0, 255);
            textColor = new Color32(255, 255, 255, 255);

            cb.normalColor = new Color32(255, 0, 0, 255);
            cb.pressedColor = new Color32(255, 0, 0, 255);
            cb.selectedColor = new Color32(193, 23, 23, 255);
            cb.highlightedColor = new Color32(0, 180, 7, 255);
        } else { // You Won
            image.color = new Color32(245, 245, 245, 255);
            textColor = new Color32(0, 0, 0, 255);

            cb.normalColor = new Color32(255, 48, 255, 255);
            cb.pressedColor = new Color32(255, 48, 255, 255);
            cb.selectedColor = new Color32(255, 48, 255, 255);
            cb.highlightedColor = new Color32(0, 180, 7, 255);
        }

        // Change Text Color
        foreach (Transform child in devCredits.transform) {
            child.GetComponent<TextMeshProUGUI>().overrideColorTags = true;
            child.GetComponent<TextMeshProUGUI>().color = textColor;
        }

        title.GetComponent<TextMeshProUGUI>().overrideColorTags = true;
        title.GetComponent<TextMeshProUGUI>().color = textColor;
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }
}
