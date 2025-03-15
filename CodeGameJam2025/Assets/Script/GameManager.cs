using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool firstGame = true;
    public bool hasChangeWeapon = false;
    public int score;
    public Canvas scoreManager;
    private ScoreManager _scoreManager;
    public GameObject enemySpawner;
    public EnnemySpawner _ennemySpawner;
    public bool isFinished = false;
    public Canvas gameOver;
    private GameOverUI gameOverUI;
    public int nbEnemy;
    public int maxScore;
    public GameObject playerPrefab;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
        gameOverUI = gameOver.GetComponent<GameOverUI>();
        _scoreManager = scoreManager.GetComponent<ScoreManager>();
        _ennemySpawner = enemySpawner.GetComponent<EnnemySpawner>();
        gameOver.enabled = false;
        gameOverUI.cacher();

    }

    // Update is called once per frame
    void Update()
    {
        nbEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        score = _scoreManager.score;
        
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && isFinished)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        isFinished = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        GameObject player2 = Instantiate(playerPrefab, new Vector2(0,0), Quaternion.identity);

        ImportShoot importShoot = player2.GetComponent<ImportShoot>();
        importShoot.camera = mainCamera;

        death d = player2.GetComponent<death>();
        d.gameManager = this;

        if(importShoot.camera != null)
        {
            importShoot.camera = mainCamera;
        }

        if(d.gameObject != null)
        {
            d.gameManager = this;
        }

        DestroyAllWithTag("Enemy");
        isFinished = false;
        gameOver.enabled = false;
        gameOverUI.cacher();
        scoreManager.enabled = true;
        _ennemySpawner.isEnable = true;
        _scoreManager.restart();
        _scoreManager.maxScore = this.maxScore;
    }

    public void gameFinished()
    {
        hasChangeWeapon = false;
        gameOver.enabled = true;
        _scoreManager.end();
        this.maxScore = _scoreManager.maxScore;
        isFinished = true;
        gameOverUI.afficher();
        scoreManager.enabled = false;
        _ennemySpawner.stop();
    }

    void DestroyAllWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
