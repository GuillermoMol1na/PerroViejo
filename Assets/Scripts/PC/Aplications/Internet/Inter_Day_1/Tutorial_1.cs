using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial_1{

        RectTransform transTutorial;
        //Declare the Btton
        TMP_Text btnText;
        Image btnImage;
        RectTransform transBtn;
        RectTransform transTextBtn;
        Sprite btnSprite;
        Vector2 dimensions;
        TMP_FontAsset pixelFontT;
        string[] gameMessage = {"Estás a punto de iniciar el minijuego, recuerda seguir las recomendaciones del librero, ten en cuenta que no podrás salir de la ventana una vez iniciado. Si te sientes preparado/a, haz click en aceptar.",
                                "Felicidades, lograste descargar las canciones deseadas sin descargar troyanos. Tus tareas por hoy han finalizado"};

        public GameObject TutorialText(GameObject tutorialT, int won){
            TMP_Text turtorialText = tutorialT.AddComponent<TextMeshProUGUI>();
            transTutorial = tutorialT.GetComponent<RectTransform>();
            transTutorial.sizeDelta=new Vector2(1667f, 466f);
            turtorialText.font=pixelFontT;
            turtorialText.fontSize=65f;
            turtorialText.color= new Color32(0,0,0,255);
            turtorialText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
            turtorialText.text=gameMessage[won];
            return tutorialT;
        }
        public GameObject TutorialButton(GameObject acceptBtnObj, Sprite theSprite){
            btnImage = acceptBtnObj.AddComponent<Image>();
            transBtn = acceptBtnObj.GetComponent<RectTransform>();
            btnSprite = theSprite;
            dimensions = btnSprite.bounds.size;
            btnImage.sprite = btnSprite;
            transBtn.sizeDelta = dimensions*5f;
            return acceptBtnObj;
        }
        public GameObject TutorialTextBtn(GameObject textBtnObject){
            btnText = textBtnObject.AddComponent<TextMeshProUGUI>();
            transTextBtn = btnText.GetComponent<RectTransform>();
            transTextBtn.sizeDelta = new Vector2(265f,91f);
            btnText.fontSize=60f;
            btnText.color=new Color32(0,0,0,255);
            btnText.font=pixelFontT;
            btnText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Midline;
            btnText.text = "Aceptar";
            return textBtnObject;
        }
        public void SetFont(TMP_FontAsset font){
            pixelFontT=font;
        }
}
