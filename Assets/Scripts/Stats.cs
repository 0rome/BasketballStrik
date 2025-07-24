using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI lastScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        lastScoreText.text = PlayerPrefs.GetInt("LastScore").ToString();
    }
}
