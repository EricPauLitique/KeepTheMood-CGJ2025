using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI bestScoreValue;
    public TextMeshProUGUI scoreValue;
    public bool isDone = false;

    

    public void afficher()
    {
        if (isDone) return;
        enabled = true;
        isDone = true;
        scoreValue.text = "Score : " + scoreManager.score.ToString();
        bestScoreValue.text = "Meilleur score : " + scoreManager.maxScore.ToString();
    }
    public void cacher()
    {
        enabled = false;
        isDone = false;
    }
}
