using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] Text roundText;
    [SerializeField] Text scoreText;
    [SerializeField] Round round;
    [SerializeField] Score score;

    private void OnEnable()
    {
        roundText.text = "Round :- " + round.GetCurrentRound();
        scoreText.text = "Score :- " + score.GetScore();
    }

}
