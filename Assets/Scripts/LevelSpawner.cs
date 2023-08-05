using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSpawner : MonoBehaviour
{

    public GameObject[] obstacleModel;
    [HideInInspector]
    public GameObject[] obstaclePrefab = new GameObject[4];

    public GameObject winPrefab;

    private GameObject tempObstacle, temp2Obstacle;

    private int level = 1, addNumber = 7;

    float obstacleNumber;

    void Start()
    {
        randomObstacleGenerator();

        for(obstacleNumber = 0; obstacleNumber > -level - addNumber; obstacleNumber -= 0.5f)
        {
            if(level <= 20)
            {
                tempObstacle = Instantiate(obstaclePrefab[Random.Range(0, 2)]);
            }

            if (level > 20 && level < 50)
            {
                tempObstacle = Instantiate(obstaclePrefab[Random.Range(1, 3)]);
            }

            if (level > 50 && level < 100)
            {
                tempObstacle = Instantiate(obstaclePrefab[Random.Range(2, 4)]);
            }

            if (level > 100)
            {
                tempObstacle = Instantiate(obstaclePrefab[Random.Range(3, 4)]);
            }


            tempObstacle = Instantiate(obstaclePrefab[Random.Range(0, 2)]);
            tempObstacle.transform.position = new Vector3(0, obstacleNumber - 0.01f, 0);
            tempObstacle.transform.eulerAngles = new Vector3(0, obstacleNumber *8,0);
            tempObstacle.transform.parent = FindObjectOfType<RotateManager>().transform;
        }

        temp2Obstacle = Instantiate(winPrefab);
        temp2Obstacle.transform.position = new Vector3(0, obstacleNumber - 0.01f, 0);
    }


    void Update()
    {
        
    }

    public void randomObstacleGenerator()
    {
        int random = Random.Range(0,5);

        switch (random)
        {
            case 0:
                for(int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i+4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 8];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 12];
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 16];
                }
                break;
        }
    }
}
