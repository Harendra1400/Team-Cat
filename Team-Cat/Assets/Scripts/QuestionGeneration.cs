using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultipleChoiceQuestions : MonoBehaviour
{   
    public Text questionTextArea;
    public Button[] optionButtons;
    //public Weapon forShoot;
    public Text scoreCount;

    private int operand1;
    private int operand2;
    private int correctAnswer;
    private int countScore;

    private void Start()
    {
        GenerateRandomQuestion();
        GenerateAnswerOptions();
        countScore = 0;

    }
    private void Update()
    {
        scoreCount.text = countScore.ToString();
        if (countScore == 5)
        {
            SceneManager.LoadScene("Retry");
        }
    }
    private void GenerateRandomQuestion()
    {
        operand1 = Random.Range(1, 10);
        operand2 = Random.Range(1, 10);
        correctAnswer = operand1 + operand2;

        string question = string.Format("{0} + {1} = ?", operand1, operand2);

        
        if (questionTextArea != null)
        {
            questionTextArea.text = question;
        }
    }

    private void GenerateAnswerOptions()
    {
        
        int[] answerOptions = new int[4];
        answerOptions[0] = correctAnswer;

        for (int i = 1; i < 4; i++)
        {
            int randomOption;
            do
            {
                randomOption = Random.Range(1, 19); 
            } while (System.Array.Exists(answerOptions, element => element == randomOption));

            answerOptions[i] = randomOption;
        }

       
        for (int i = answerOptions.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = answerOptions[i];
            answerOptions[i] = answerOptions[j];
            answerOptions[j] = temp;
        }

        
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (optionButtons[i] != null)
            {
                
                Text buttonText = optionButtons[i].GetComponentInChildren<Text>();
                buttonText.text = answerOptions[i].ToString();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(int.Parse(buttonText.text)));
            }
        }
    }


    private void CheckAnswer(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            countScore += 1;
            Debug.Log("Correct Answer!");
            //forShoot.Shoot();
            GenerateRandomQuestion();
            GenerateAnswerOptions();
            //countScore += 1;
            //temp rng

        }
        else
        {
            
            Debug.Log("Incorrect Answer. Try again.");
        }
    }
}






