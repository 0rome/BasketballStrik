using UnityEngine;
using DG.Tweening;

public class ButtonsAnim : MonoBehaviour
{
    [SerializeField] private bool LoopAnimation = false;

    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        if (LoopAnimation)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 1f).SetUpdate(true));
            seq.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 1f).SetUpdate(true));
            seq.SetLoops(-1); // бесконечный цикл
        }
    }

    public void OnClickButton()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f).SetUpdate(true));
        sequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f).SetUpdate(true));
    }
    
}
