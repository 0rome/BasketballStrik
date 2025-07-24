using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeMode : GameMode
{
    public static TimeMode Instance { get; private set; }

    [SerializeField] private bool timerIsActive = true;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject LoseMenu;

    [SerializeField] private float timer = 300f; // 5 минут
    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Удаляем дубликаты
            return;
        }

        Instance = this;
    }

    void Update()
    {
        if (timerIsActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timer = 0;
                UpdateTimerDisplay();
                Win();
            }
        }
        
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public override void Lose()
    {
        base.Lose();

        LoseMenu.SetActive(true);
    }
    public override void Win()
    {
        base.Win();

        PlayerPrefs.SetInt("Level_" + SceneManager.GetActiveScene().buildIndex,1);

        player.SetActive(false);
        WinMenu.SetActive(true);
    }
}
