using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int maxScore;
    public TextMeshProUGUI bestScoreValue;
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI saturation;
    private int nbEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreValue.text = score.ToString();
        bestScoreValue.text = maxScore.ToString();
        nbEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        saturation.text = "nombre d'ennemi(s) : " + nbEnemies.ToString() + "/30";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreValue.text = score.ToString();
        bestScoreValue.text = maxScore.ToString();
        nbEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        saturation.text = "nombre d'ennemi(s) : " + nbEnemies.ToString() + "/30";
    }

    public void addScore(int points)
    {
        score += points;
    }

    public void end()
    {
        if (maxScore < score)
        {
            maxScore = score;
        }

    }

    public void restart()
    {
        score = 0;
    }
}
