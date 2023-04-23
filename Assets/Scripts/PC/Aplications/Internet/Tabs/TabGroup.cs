using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<OurTabButton> tabButtons;
    private Sprite tabIdle;
    private Sprite tabHover;
    private Sprite tabActive;
    public OurTabButton selectedTab;
    List<OurTabButton> sublist;
    public List<GameObject> objectsToSwap;
    int obj;
    int listsize;
    
    void Start(){
        tabIdle=Resources.Load<Sprite>("Internet_Browser_2");
        tabHover=Resources.Load<Sprite>("Tab_Alternatives_0");
        tabActive=Resources.Load<Sprite>("Tab_Alternatives_1");
    }
    public void TabSystem(OurTabButton button){   
        if(tabButtons==null){
            tabButtons= new List<OurTabButton>();
        }
        tabButtons.Add(button);

    }
    public void WindowSystem(GameObject window){

        if(objectsToSwap==null){
            objectsToSwap= new List<GameObject>();
        }
        //Adding the new windowtab to the list
        objectsToSwap.Add(window);
    }
    public void RemoveTab(OurTabButton button){
        tabButtons.Remove(button);
        obj = button.transform.GetSiblingIndex();
        listsize= tabButtons.Count;
        /*Debug.Log("Por supuesto se elimina el TAB con índice: "+obj );
        Debug.Log("HAciendo que la lista tenga un tamaño de: "+listsize );*/
        if(listsize > obj){
            sublist = tabButtons.GetRange(obj,listsize-1);
            foreach(OurTabButton tab in sublist){
                tab.MoveTab();
            }   
        }
        objectsToSwap[obj].SetActive(false);
        objectsToSwap.RemoveAt(obj);

        if(this.transform.childCount == 1){
            this.transform.GetChild(0).GetComponent<OurTabButton>().FirstTabPosition();
        }
    }
    public void OnTabEnter(OurTabButton button){
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
            button.background.sprite= tabHover;
    }
    public void OnTabExit(OurTabButton button){
        ResetTabs();
    }
    public void OnTabSelected(OurTabButton button){
        selectedTab=button;
        ResetTabs();
        button.background.sprite= tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i=0; i<objectsToSwap.Count;i++){
            if(i==index){
                objectsToSwap[i].SetActive(true);
            }else{
                objectsToSwap[i].SetActive(false);
            }
        }

    }
    public void ResetTabs(){
        foreach(OurTabButton button in tabButtons){
            if(selectedTab != null && button == selectedTab) { continue ; }
                button.background.sprite = tabIdle;
        }

    }
    void OnEnable(){
        Internet_App.emptyLists += EmptyTabWinLists;
    }
    void OnDisable(){
        Internet_App.emptyLists -= EmptyTabWinLists;
    }

    void EmptyTabWinLists(){
        objectsToSwap.Clear();
        tabButtons.Clear();
    }
}
