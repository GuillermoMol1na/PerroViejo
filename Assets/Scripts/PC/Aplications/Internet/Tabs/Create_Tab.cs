using UnityEngine;
using UnityEngine.UI;

public class Create_Tab
{
    private RectTransform transTab;
    private TabButton tabScript;
    private Image tabImage;
    private Button tabButton;
    private RectTransform transWin;
    private Image imageWin;
    private InterWind interWindow;

    public GameObject createTabBtn(GameObject theTab,TabGroup theTabGroup,  Sprite tabSprite){
            transTab = theTab.AddComponent<RectTransform>();
            transTab.anchoredPosition = new Vector2(0f, 0f);
            
            transTab.sizeDelta = new Vector2(6307.58f, 3436.84f);
            transTab.pivot = new Vector2(0.5f, 0.5f);
            transTab.localScale = new Vector3(1f/45,1f/45,1f/45);
            //Adding the Tab Script
            tabScript=theTab.AddComponent<TabButton>();
            tabScript.tabGroup=theTabGroup;
            //Adding Tab Image
            tabImage = theTab.AddComponent<Image>();
            tabImage.sprite = tabSprite;
            tabImage.GetComponent<Image>().type=Image.Type.Simple;
            //Adding the button to the tab
            tabButton = theTab.AddComponent<Button>();
            tabButton.targetGraphic=tabImage;
        return theTab;
    }
    public GameObject createTabWindow(GameObject theWindow, TabGroup theTabGroup){
            transWin = theWindow.AddComponent<RectTransform>();
            transWin.anchoredPosition = new Vector2(0f, 0f);
            
            transWin.sizeDelta = new Vector2(86266.13f, 42037f);
            transWin.pivot = new Vector2(0.5f, 0.5f);
            transWin.localScale = new Vector3(1f/45,1f/45,1f/45);
            imageWin= theWindow.AddComponent<Image>();
            imageWin.GetComponent<Image>().color = new Color32(255,255,255,255); 
            interWindow= theWindow.AddComponent<InterWind>();
            interWindow.tabGroup = theTabGroup;
        return theWindow;
    }
}
