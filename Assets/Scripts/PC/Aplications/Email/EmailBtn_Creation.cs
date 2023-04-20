using UnityEngine;
using UnityEngine.UI;

public class EmailBtn_Creation
{
    private Email emailScript;
    private GameObject icon;
    private RectTransform trans;
    private RectTransform othertrans;
    private Image image;
    private Image imageRead;
    private Button buton;
    public GameObject CreateBtn(GameObject email, int index, Sprite background, string emailText, string linkAttatched){

            trans = email.AddComponent<RectTransform>();
            trans.anchoredPosition = new Vector2(0f, 0f);
            trans.localPosition = new Vector3(0, 0, 0);
            trans.pivot = new Vector2(0.5f, 0.5f);
            trans.localScale = new Vector3(1f/45,1f/45,1f/45);
            trans.sizeDelta = new Vector2(49045.09f, 6976.12f);
            //Adding the EmailScript
            emailScript = email.AddComponent<Email>();
            emailScript.SetEmail(emailText, linkAttatched);
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
    public GameObject CreateReadorNot(Sprite readNot){
        //Adding Read Sprite
            icon =  new GameObject("Read_or_Not_Image");
            othertrans = icon.AddComponent<RectTransform>();
            othertrans.anchoredPosition = new Vector2(0f, 0f);
            othertrans.localPosition = new Vector3(21411f, 0.00022125f, 0);
            othertrans.localScale = new Vector3(45f,45f,45f);
            othertrans.sizeDelta = new Vector2(100f,100f);
            imageRead = icon.AddComponent<Image>();
            imageRead.sprite = readNot;
            imageRead.GetComponent<Image>().type= Image.Type.Simple;
            return icon;
    }
}
