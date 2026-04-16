using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour
{
    public bool isBoolean = false;
    public GameObject[] answers;
    public string[] answerText;
    public string wrongText = "Incorrect!";
    public int correctIndex;

    private GameController gameController;

    void Awake() {
        gameController = FindAnyObjectByType<GameController>();
    }

    void Start() {
        for (int i = 0; i < 4; i++) {
            Button button =  answers[i].GetComponent<Button>();
            // Change Disabled Color
            ColorBlock cb = button.colors;
            if (i == correctIndex) {
               button.onClick.AddListener(Correct);
               cb.disabledColor = new Color(0f, 255f, 0f);
            } else {
                button.onClick.AddListener(delegate{Wrong(button); });
                cb.disabledColor = new Color(255f, 0f, 0f);
            }
            button.colors = cb;

            // Change Text
            button.GetComponentInChildren<TextMeshProUGUI>().text = answerText[i];
        }
    }

    public void Correct() {
        // Disable All Buttons
        for (int i = 0; i < 4; i++) {
            answers[i].GetComponent<Button>().interactable = false;
        }
        // Change Answer Text
        this.GetComponentInChildren<TextMeshProUGUI>().text = "Correct!";

        // Add a life if less than 10
        if (gameController.lives < 10) {
            gameController.lives++;
        }

        // Show Next Question Button
        gameController.next.GetComponent<Button>().interactable = true;
        gameController.next.GetComponentInChildren<TextMeshProUGUI>().text = "Next Question";
    }

    public void Wrong(Button button) {
        // Disable Answer and take a life
        button.interactable = false;
        gameController.lives--;

        gameController.next.GetComponentInChildren<TextMeshProUGUI>().text = wrongText;
    }
}
