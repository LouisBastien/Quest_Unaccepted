using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject PNJ1;
    public GameObject PNJ2;
    public GameObject PNJ3;
    public GameObject PNJ4;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private GameObject ennemie;

    void Start() {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update() {

    }

    void Spawn()
    {
        if (GameManager.onPause == false)
        {
            int number = Random.Range(1, 5);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            if (number == 1)
            {
                Instantiate(PNJ1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            if (number == 2)
            {
                Instantiate(PNJ2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            if (number == 3)
            {
                Instantiate(PNJ3, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            {
                Instantiate(PNJ4, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
    }
}
