using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints = new GameObject[4];
    public GameObject trash;
    public GameObject trashPrefab;
    public static int trashCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Point");
        GenerateTrash();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GenerateTrash()
    {
        int randVal = 0;

        randVal = Random.Range(0, 4);
        trash = Instantiate(trashPrefab);

        switch (randVal)
        {
            case 0:
                {
                    trash.transform.position = spawnPoints[0].transform.position;
                    break;
                }
            case 1:
                {
                    trash.transform.position = spawnPoints[1].transform.position;
                    break;
                }
            case 2:
                {
                    trash.transform.position = spawnPoints[2].transform.position;
                    break;
                }
            case 3:
                {
                    trash.transform.position = spawnPoints[3].transform.position;
                    break;
                }
        }

       // Camera.main.GetComponent<DynamicCamera>().ListOfFollowing.Add(trash.transform);
        trashCounter++;
    }
}
