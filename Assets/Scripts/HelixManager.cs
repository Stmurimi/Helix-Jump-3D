using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringsDistance = 5;

    public int noOfRings;

    // Start is called before the first frame update
    void Start()
    {
        noOfRings = GameManager.currentLevelIndex + 5;

        for(int i = 0; i < noOfRings; i++)
        {
            if (i == 0)
            
                SpawnRing(0);

            else 

                SpawnRing(Random.Range(1, helixRings.Length - 1));
            
        }

        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringsDistance;

    }
}
