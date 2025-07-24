using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource soundsAudiosource;
    [SerializeField] private AudioSource musicAudiosource;

    [SerializeField] private Slider soundsSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private AudioClip[] Clips;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundsAudiosource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("MusicVolume") == false)
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        }
        if (PlayerPrefs.HasKey("SoundsVolume") == false)
        {
            PlayerPrefs.SetFloat("SoundsVolume", 1);
        }

        musicAudiosource.volume = PlayerPrefs.GetFloat("MusicVolume");
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        soundsAudiosource.volume = PlayerPrefs.GetFloat("SoundsVolume");
        if (soundsSlider != null)
        {
            soundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
        }
    }

    public void MakeSound(int soundIndex)
    {
        soundsAudiosource.PlayOneShot(Clips[soundIndex]);
    }
    public void ChangeMusicVolume()
    {
        musicAudiosource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    public void ChangeSoundsVolume()
    {
         soundsAudiosource.volume = soundsSlider.value;
         PlayerPrefs.SetFloat("SoundsVolume", soundsSlider.value);
    }
}

