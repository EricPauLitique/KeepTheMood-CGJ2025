using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public Ennemy[] enemyPrefab;
    public float delayTime;
    public float selection = 0;
    [SerializeField] private AnimationCurve SpawnCurve;
    [SerializeField] public GameObject[] SpawnObject;
    public ScoreManager scoreManager;
    public float YMin;
    public float YMax;
    public float XMin;
    public float XMax;
    public bool isEnable = true;
    public int coefficient;


    // met le premier delai
    void Start()
    {
        isEnable = true;
        selection = 0;
        delayTime = SpawnCurve.Evaluate(selection);
        YMin = SpawnObject[1].transform.position.y;
        YMax = SpawnObject[0].transform.position.y;
        XMax = SpawnObject[3].transform.position.x;
        XMin = SpawnObject[1].transform.position.x;
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            enemyPrefab[i].scoreManager = scoreManager;
        }
    }

    // Update avec interval fixe
    void FixedUpdate()
    {
        
        if (!isEnable)
        {
            selection = 0;
            return;
        }
        if(delayTime > 0)
        {
            delayTime -= 0.02f;
            return;
        }
        
        handleSpawn();
        
    }

    void handleSpawn()
    {
        int randomIndex = Random.Range(0, 4);
        int randomCar = Random.Range(0, enemyPrefab.Length);
        Ennemy car = enemyPrefab[randomCar];
        car.scoreManager = scoreManager;
        
        switch (randomIndex)
        {
            case 0:
                float randomY = Random.Range(YMin, YMax);
                Instantiate(car, new Vector2(XMin, randomY), Quaternion.identity);

                break;
            case 1:
                float randomX = Random.Range(XMin, XMax);
                Instantiate(car, new Vector2(randomX, YMax), Quaternion.identity);
                break;
            case 2:
                randomY = Random.Range(YMin, YMax);
                Instantiate(car, new Vector2(XMax, randomY), Quaternion.identity);
                break;
            case 3:
                randomX = Random.Range(XMin, XMax);
                Instantiate(car, new Vector2(randomX, YMin), Quaternion.identity);
                break;
        }

        if(selection != 1)
        {
            selection += .01f;
        }
        delayTime = SpawnCurve.Evaluate(selection) * 2;

    }
    public void stop()
    {
        isEnable = false;
    }

}
