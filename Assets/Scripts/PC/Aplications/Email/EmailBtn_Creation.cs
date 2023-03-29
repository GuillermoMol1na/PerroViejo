using UnityEngine;
using UnityEngine.UI;

public class EmailBtn_Creation
{
    private Email emailScript;
    private Image image;
    private Button buton;
    public GameObject CreateBtn(GameObject email, int index, Sprite background){

        RectTransform trans = email.AddComponent<RectTransform>();
            trans.anchoredPosition = new Vector2(0f, 0f);
            trans.localPosition = new Vector3(0, 0, 0);
            trans.pivot = new Vector2(0.5f, 0.5f);
            trans.localScale = new Vector3(1f/45,1f/45,1f/45);
            trans.sizeDelta = new Vector2(49045.09f, 6976.12f);
            //Adding the EmailScript
            emailScript = email.AddComponent<Email>();
             //Adding the image
            image = email.AddComponent<Image>();
            image.sprite = background;
            image.GetComponent<Image>().type= Image.Type.Sliced;
            //Adding Button
            buton = email.AddComponent<Button>();
            buton.targetGraphic= image;
            buton.onClick.AddListener( emailScript.OpenEmail);
        return email;
    }
}
