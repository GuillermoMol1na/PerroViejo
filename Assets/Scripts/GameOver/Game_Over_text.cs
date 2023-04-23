using UnityEngine;
using TMPro;
public class Game_Over_text : MonoBehaviour
{
    private TMP_Text gameOverText;
    private string endGame;
    void Start()
    {
        gameOverText = gameObject.GetComponent<TextMeshProUGUI>();

        switch(PlayerPrefs.GetInt("day")){
        case 0:
            endGame = "Un gusano infectó la PC de Erwin";
        break;
        case 1:
            endGame = "Un gusano infectó la PC de Erwin";
        break;
        case 2:
            endGame = "Erwin fue estafado mediante Phishing";
        break;
        }
        gameOverText.text = endGame;
    }

}
