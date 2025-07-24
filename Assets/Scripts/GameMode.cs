using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    [SerializeField] GameObject MenuButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void HideMenuButton()
    {
        MenuButton.SetActive(false);
    }
    public virtual void Lose()
    {
        HideMenuButton();
    }
    public virtual void Win()
    {
        HideMenuButton();
    }
}
