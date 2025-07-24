using TMPro;
using UnityEngine;

public class SurvivalMode : GameMode
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject LoseMenu;

    private int currentScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }

    public void ReloadScore()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public override void Lose()
    {
        base.Lose();

        LoseMenu.SetActive(true);

        PlayerPrefs.SetInt("LastScore", currentScore);

        if (currentScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore",currentScore);
        }
    }
    public override void Win()
    {
        base.Win();

        WinMenu.SetActive(true);
    }
}
