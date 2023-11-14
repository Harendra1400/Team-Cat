using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MathGameController : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public Text scoreText;
    //public Weapon weapon;
    public int score = 0;
    private int correctAnswer;
    private int x1, x2;
    public int x;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;


    void Start()
    {
        x = 0;
        GenerateQuestion();
    }


    void GenerateQuestion()
    {
        int num1 = Random.Range(1, 10);
        x1 = num1;
        int num2 = Random.Range(1, 10);
        x2 = num2;
        correctAnswer = num1 + num2;

        questionText.text = num1 + "  +  " + num2 + "  =   ?";

        List<int> answerOptions = new List<int>();
        answerOptions.Add(correctAnswer);
        while (answerOptions.Count < answerButtons.Length)
        {
            int wrongAnswer = Random.Range(1, 19);
            if (!answerOptions.Contains(wrongAnswer))
            {
                answerOptions.Add(wrongAnswer);
            }
        }

        Shuffle(answerOptions);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answerOptions[i].ToString();
        }
    }


    void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }



    /*void ShuffleAnswerButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int randIndex = Random.Range(i, answerButtons.Length);
            Button tempButton = answerButtons[i];
            answerButtons[i] = answerButtons[randIndex];
            answerButtons[randIndex] = tempButton;
        }
    }*/

    
    public void CheckAnswer(Text selectedButtonText)
    {
        string selectedAnswer = selectedButtonText.text;

        Debug.Log("Selected Answer: " + selectedAnswer); 

        int selectedNumber;
        if (int.TryParse(selectedAnswer, out selectedNumber))
        {
            if (selectedNumber == correctAnswer)
            {
                Debug.Log("correct");
                //weapon.ring();
                x = 1;
                score++;
                Debug.Log(score);
                Debug.Log("x val:"+ x);
                scoreText.text = score.ToString();
                Invoke("GenerateQuestion", 1.0f);
            }
            else
            {
                Debug.Log("incorrect");
                questionText.text = x1 + "  +  " + x2 + "  =  " + correctAnswer;
                Invoke("GenerateQuestion", 2.0f);

            }
        }
        else
        {
            Debug.Log("failed");
           
        }
        if (score == 1)
        {
            Invoke("Delay2", 1.0f);         
        }
        else if (score == 2)
        {
            Invoke("Delay3", 1.0f);            
        }
        else if (score == 3)
        {
            Invoke("Delay4", 1.0f);          
        }
        else if (score == 4)
        {
            Invoke("Delay5", 1.0f);
        }
        else if (score == 5)
        {
            Invoke("sceneswitch", 1.0f);
        }
    }
    private void sceneswitch()
    {
        SceneManager.LoadScene("LevelComplete");
    }
    private void Delay2()
    {
        monster2.SetActive(true);
    }
    private void Delay3()
    {
        monster3.SetActive(true);
    }
    private void Delay4()
    {
        monster4.SetActive(true);
    }
    private void Delay5()
    {
        monster5.SetActive(true);
    }

}
