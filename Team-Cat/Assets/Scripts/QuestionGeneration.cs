using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MultipleChoiceQuestions : MonoBehaviour
{   
    public Text questionTextArea;
    public Button[] optionButtons;
    //public Weapon forShoot;
    public Text scoreCount;
    //private Vector3 originalPosition;
    //public int x;
    //public GameObject monsterYellow;

    private int operand1;
    private int operand2;
    private int correctAnswer;
    private int countScore;
    //private int answer;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;

    private void Start()
    {
        GenerateRandomQuestion();
        GenerateAnswerOptions();
        countScore = 0;
        //answer = 0;
        scoreCount.text = countScore.ToString();
        //originalPosition = transform.position;
        //x = 0;
    }
    private void Update()
    {   Debug.Log(countScore.ToString());
        if (countScore > 15)
        {
            //SceneManager.LoadScene("LevelComplete");
            Invoke("sceneswitch", 2.0f);
        }
    }
    private void GenerateRandomQuestion()
    {
        Debug.Log("generated");

        operand1 = Random.Range(1, 10);
        operand2 = Random.Range(1, 10);
        correctAnswer = operand1 + operand2;

        string question = string.Format("{0} + {1} = ?", operand1, operand2);

        if (questionTextArea.text != null)
        {
            questionTextArea.text = question;
        }
    }

    private void GenerateAnswerOptions()
    {
        Debug.Log("gennie");
        
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

        //int selectedValue=0;
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (optionButtons[i] != null)
            {

                Text buttonText = optionButtons[i].GetComponentInChildren<Text>();
                buttonText.text = answerOptions[i].ToString();
                //string buttonText = optionButtons[i].GetComponentInChildren<Text>().text;

                    
                    optionButtons[i].onClick.AddListener(() => CheckAnswer(int.Parse(buttonText.text)));
                    
                
            }
        }
        //CheckAnswer(selectedValue);


    }


    private void CheckAnswer(int selectedanswer)
    {   
        //Text tmp = clickedButton.GetComponentInChildren<Text>();
        //int value = int.Parse(tmp.text);   
       // Debug.Log(value);
        if (selectedanswer == correctAnswer)
        {
            scorecheck();
            //Debug.Log("hello");
            
            Debug.Log(countScore.ToString());
            if(countScore == 1)
            {
                Invoke("Delay2", 2.0f);
                
            }
            else if (countScore == 3)
            {
                Invoke("Delay3", 2.0f);
               
            }
            else if(countScore == 5)
            {
                Invoke("Delay4", 2.0f);
                
            }
            else if(countScore == 15)
            {
                Invoke("Delay5", 2.0f);
            }
        }
        else
        {
            string question = string.Format("{0} + {1} = {2}", operand1, operand2 , operand1+operand2);
            questionTextArea.text = question;
            Debug.Log("Incorrect Answer. Try again.");
        }
        Invoke("GenerateRandomQuestion", 2.0f);
        Invoke("GenerateAnswerOptions", 2.0f);
    }
    private void scorecheck()
    {   

       // if (countScore <5) {
            countScore++;
        //}
        /*if(countScore == 5) {
            Invoke("sceneswitch", 2.0f);
        }*/

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






