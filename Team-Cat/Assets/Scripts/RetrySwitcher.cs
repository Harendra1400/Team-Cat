using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySwitcher : MonoBehaviour
{
    public string sceneToLoad;
    private MultipleChoiceQuestions m1;
    public int cd;
    private void Start()
    {
        cd = m1.x;
    }

    private void Update()
    {
        if (cd >= 5)
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }
}

