using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Image fadeTransitionImage;

    private void Start()
    {
        Application.targetFrameRate = 60;

        fadeTransitionImage.gameObject.SetActive(true);
        fadeTransitionImage.DOFade(0f, 1f).SetUpdate(true);
    }

    public void LoadScene(int sceneIndex)
    {
        Resume();
        StartCoroutine(fade(sceneIndex));
    }
    public void NextScene()
    {
        StartCoroutine(fade(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void RestartScene()
    {
        Resume();
        StartCoroutine(fade(SceneManager.GetActiveScene().buildIndex));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private IEnumerator fade(int sceneIndex)
    {
        fadeTransitionImage.DOFade(1f, 1f).SetUpdate(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
