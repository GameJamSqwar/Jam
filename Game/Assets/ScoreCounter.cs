using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float score = 0;

    public void AddToScore(float value)
    {
        score += value;
    }

    public float GetScore()
    {
        return score;
    }
}
