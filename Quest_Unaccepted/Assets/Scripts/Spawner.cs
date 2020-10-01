using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    [Space]
    public Transform PnjParent = null;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public void Start() {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        if (GameManager.onPause == false)
        {
            int number = Random.Range(1, 5);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            if (number == 1)
            {
                Instantiate(npc1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation, PnjParent.transform);
            }
            else
            if (number == 2)
            {
                Instantiate(npc2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation, PnjParent.transform);
            }
            else
            if (number == 3)
            {
                Instantiate(npc3, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation, PnjParent.transform);
            }
            else
            {
                Instantiate(npc4, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation, PnjParent.transform);
            }
        }
    }
}
