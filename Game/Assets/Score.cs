using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int combo = 0;
    Text score;


    private void Start()
    {
        score = GetComponent<Text>();
    }


    public Text scoreText;
    // Update is called once per frame
    void Update()
    {
        if (combo > 0)
        {
            score.text = "Score: " + scoreValue.ToString() + "\n Combo: " + combo.ToString();
        }
        else
        {
            score.text = "Score: " + scoreValue.ToString();
        }
    }

    public void AddToScore(int value)
    {
        Debug.Log("adding to score");
        scoreValue += (value + combo);
    }

    public void ResetScore()
    {
        scoreValue = 0;
    }

    public void IncreaseCombo()
    {
        combo += 10;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
