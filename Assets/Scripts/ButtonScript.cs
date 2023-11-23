using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] Button _btn;
    public TMP_Text AnswerText;

    public void BtnClick()
    {
        GameManager.ButtonPressed(this);
    }
    public void ChangeColor(Color color)
    {
        _btn.image.color = color;
    }
}
