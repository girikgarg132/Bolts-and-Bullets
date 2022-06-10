using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    [SerializeField] Text currentRoundText;

    int currentRound = 0;

    public int GetCurrentRound()
    {
        return currentRound;
    }

    public void IncreamentCurrentRound()
    {
        currentRound++;
    }

    public int GetNoOfEnimes()
    {
        return currentRound * 10;
    }

    private void Update()
    {
        currentRoundText.text = "Round : " + currentRound;
    }

}

