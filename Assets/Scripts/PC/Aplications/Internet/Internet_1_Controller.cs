using UnityEngine;
using UnityEngine.UI;

public class Internet_1_Controller : MonoBehaviour
{
    private GameObject interPanel;
    private GameObject objWindow;
    private GameObject interTab;
    private GameObject theWindow;
    private GameObject theTab;
    //Must be changed to 6255
    private float tabPosX = -6298;
    private int nameOrder=1;
    private Sprite tabSprite;
    //Must move to the creation of tabs script
    private TabGroup theTabGroup;
    private Create_Tab TabCreator = new Create_Tab();

    void Start()
    {
        interPanel = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        objWindow = interPanel.transform.Find("Internet_Content").gameObject;
        interTab = interPanel.transform.Find("Tab_Area").gameObject;
        //This must not remain here
        theTabGroup = interTab.GetComponent<TabGroup>();
        tabSprite= Resources.Load<Sprite>("Internet_Browser_2");
    }
    public void NewTabwindow(){
 
            theWindow= new GameObject("Window"+nameOrder.ToString());
            theTab= new GameObject("Tab"+nameOrder.ToString());
            //Creating the Window
            theWindow= TabCreator.createTabWindow(theWindow, theTabGroup);
            //Creating the Tab
            theTab = TabCreator.createTabBtn(theTab, theTabGroup, tabSprite);
            //Setting the parents
            theWindow.transform.SetParent(objWindow.transform);
            theTab.transform.SetParent(interTab.transform);
            //The transform of Tab is setted here
            theTab.transform.localPosition=new Vector3(tabPosX,0f,0f);
            theWindow.transform.localPosition=new Vector3(190.97f,0.35294f,0f);
            
            tabPosX =tabPosX+ 7342f;
            nameOrder = nameOrder+1;
    }
}
