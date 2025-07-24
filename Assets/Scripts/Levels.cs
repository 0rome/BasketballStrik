using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameObject[] checks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.GetInt("Level_" + i, 0) == 1 && i - 1 < checks.Length)
            {
                checks[i - 1].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
