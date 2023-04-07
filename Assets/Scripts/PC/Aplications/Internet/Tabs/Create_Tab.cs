using UnityEngine;
using UnityEngine.UI;

public class Create_Tab
{
    private RectTransform transTab;
    private TabButton tabScript;
    private Image tabImage;
    private Button tabButton;


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
}
