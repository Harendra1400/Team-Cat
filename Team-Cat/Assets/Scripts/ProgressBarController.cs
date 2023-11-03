using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{

public Text ValueText;
    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString();
    } 
}