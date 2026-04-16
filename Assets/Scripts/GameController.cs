using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject lifeText;
    public int lives = 5;
    public GameObject[] questions;
    public GameObject next;

    public int currentIndex = 0;

    void Start() {
        questions[0].SetActive(true);
        next.GetComponent<Button>().interactable = false;
        next.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
    
    void Update() {
        lifeText.GetComponent<TextMeshProUGUI>().text = "" + lives;
        if (lives < 0) { // Game Over
            SceneManager.LoadScene(2);
        }
    }

    public void nextQuestion() {
        Destroy(questions[currentIndex]);
        currentIndex++;
        if (currentIndex < questions.Length) {
            questions[currentIndex].SetActive(true);
            next.GetComponent<Button>().interactable = false;
            next.GetComponentInChildren<TextMeshProUGUI>().text = "";
        } else { // You Passed
            SceneManager.LoadScene(3);
        }
    }
}
