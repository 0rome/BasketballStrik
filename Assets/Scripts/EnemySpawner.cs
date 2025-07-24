using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private bool isSurvival = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn());

        if (isSurvival)
        {
            if (PlayerPrefs.GetString("Dif") == "Easy")
            {
                spawnSpeed = 1;
            }
            else if (PlayerPrefs.GetString("Dif") == "Medium")
            {
                spawnSpeed = 2;
            }
            else
            {
                spawnSpeed = 3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            Instantiate(EnemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
    }
}
