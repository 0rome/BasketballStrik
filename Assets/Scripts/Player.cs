using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] ChangeSprites;
    [SerializeField] private bool isSurvival;


    private SurvivalMode survivalMode;
    private TimeMode timeMode;

    private int playerMode = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (isSurvival)
        {
            survivalMode = GameObject.FindGameObjectWithTag("SurvivalMode").GetComponent<SurvivalMode>();
        }
        else
        {
            timeMode = GameObject.FindGameObjectWithTag("TimeMode").GetComponent<TimeMode>();
        }
    }


    // Update is called once per frame
    private void PlayerChange()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f));
        sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f));

        if (playerMode == 0)
        {
            playerMode = 1;
            spriteRenderer.sprite = ChangeSprites[playerMode];
        }
        else
        {
            playerMode = 0;
            spriteRenderer.sprite = ChangeSprites[playerMode];
        }
    }
    public void PlayerAnim()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f));
        sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f));
    }
    
    public void Death()
    {
        gameObject.SetActive(false);
        if (survivalMode != null)
        {
            survivalMode.Lose();
        }
        if (timeMode != null)
        {
            timeMode.Lose();
        }
    }
    public void GetScorePoint()
    {
        if (isSurvival)
        {
            survivalMode.ReloadScore();
        }
    }
    public int GetPlayerMode()
    {
        return playerMode;
    }
}
