using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepCounterBehavior : MonoBehaviour
{
    private TMP_Text m_text;

    private int m_score;

    private void Start()
    {
        m_text = GetComponent<TMP_Text>();
    }

    public void ChangeSore(int score)
    {
        m_score = score;
        m_text.text = "Steps: " + m_score.ToString();
    }
}
