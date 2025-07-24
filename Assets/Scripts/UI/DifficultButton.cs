using UnityEngine;
using TMPro;

public class DifficultButton : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private TextMeshProUGUI difText;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("Dif"))
        {
            PlayerPrefs.SetString("Dif", "Easy");
        }
        difText.text = PlayerPrefs.GetString("Dif");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void rightButton()
    {
        if (difText.text == "Easy")
        {
            difText.text = "Medium";
        }
        else if (difText.text == "Medium")
        {
            difText.text = "Hard";
        }
        else
        {
            difText.text = "Easy";
        }
        PlayerPrefs.SetString("Dif", difText.text);
    }
    public void leftButton()
    {
        if (difText.text == "Easy")
        {
            difText.text = "Hard";
        }
        else if (difText.text == "Hard")
        {
            difText.text = "Medium";
        }
        else
        {
            difText.text = "Easy";
        }
        PlayerPrefs.SetString("Dif",difText.text);
    }
}
