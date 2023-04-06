using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    private Sprite tabIdle;
    private Sprite tabHover;
    private Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public void TabSystem(TabButton button){
        tabIdle=Resources.Load<Sprite>("Internet_Browser_2");
        tabHover=Resources.Load<Sprite>("Tab_Alternatives_0");
        tabActive=Resources.Load<Sprite>("Tab_Alternatives_1");
        if(tabButtons==null){
            tabButtons= new List<TabButton>();
        }

        tabButtons.Add(button);
    }
    public void OnTabEnter(TabButton button){
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
            button.background.sprite= tabHover;
    }
    public void OnTabExit(TabButton button){
        ResetTabs();
    }
    public void OnTabSelected(TabButton button){
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
        foreach(TabButton button in tabButtons){
            if(selectedTab != null && button == selectedTab) { continue ; }
                button.background.sprite = tabIdle;
        }
    }
}
