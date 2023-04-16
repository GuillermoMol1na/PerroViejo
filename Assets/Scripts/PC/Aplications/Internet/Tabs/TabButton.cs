using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;
    private float move= -7342f;
    private float currentX;
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.TabSystem(this);

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
        Debug.Log("Posición local del Tab es: "+this.transform.localPosition);
        if(this.transform.GetSiblingIndex()==0){
            FirstTabPosition();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void DeleteTab(){
        tabGroup.RemoveTab(this);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    public void MoveTab(){
        currentX= this.transform.localPosition.x;
        this.transform.localPosition= new Vector3(currentX+move,0f,0f);
    }
    public void FirstTabPosition(){
        this.transform.localPosition= new Vector3(-12928f,0f,0f);
    }
    void OnEnable(){
        InterWind.closeTheTab += CheckTabforClose;
    }
    void OnDisable(){
        InterWind.closeTheTab -= CheckTabforClose;
    }

    void CheckTabforClose(int winIndex){
        
        if(this.transform.GetSiblingIndex() == winIndex){
            Debug.Log("Se está eliminando el TAB con posición: "+this.transform.GetSiblingIndex() );
            DeleteTab();
        }
    }
}
