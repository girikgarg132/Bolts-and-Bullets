using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0f;

    public void IncreaseScore(float amount)
    {
        score += amount;
    }

    public float GetScore()
    {
        return score;
    }
}
