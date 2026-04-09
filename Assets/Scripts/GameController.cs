using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int lives = 5;
    public GameObject[] questions;
    public GameObject next;

    public int currentIndex = 0;

    void Start() {
        for (int i = 1; i < questions.Length; i++) {
            questions[i].SetActive(false);
        }
        next.GetComponent<Button>().interactable = false;
        next.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
    
    void Update() {
        
    }

    public void nextQuestion() {
        questions[currentIndex].SetActive(false);
        currentIndex++;
        questions[currentIndex].SetActive(true);
        next.GetComponent<Button>().interactable = false;
        next.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
}
