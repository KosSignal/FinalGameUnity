using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject lifeText;
    public int lives;
    public GameObject[] questions;
    public GameObject next; // Next question button

    public int currentIndex = 0;

    void Start() {
        lives = PlayerPrefs.GetInt("Lives");
        questions = FindObsWithTag("Question");
        for (int i = 1; i < questions.Length; i++) {
            questions[i].SetActive(false);
        }
        next.GetComponent<Button>().interactable = false;
        next.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
    
    void Update() {
        lifeText.GetComponent<TextMeshProUGUI>().text = "" + lives;
        if (lives <= 0) { // Game Over
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
            PlayerPrefs.SetInt("Lives", lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private GameObject[] FindObsWithTag(string tag) { // Creates the array
        GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
        Array.Sort(foundObs, CompareObIndex);
        return foundObs;
    }

    private int CompareObIndex(GameObject x, GameObject y) { // Sort the array
        return x.GetComponent<QuestionController>().index.CompareTo(y.GetComponent<QuestionController>().index);
    }
}
