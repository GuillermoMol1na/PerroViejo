using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;
    private float move= -7342f;
    private float currentX;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
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
        Destroy(this);
    }
    public void MoveTab(){
        currentX= this.transform.localPosition.x;
        this.transform.localPosition= new Vector3(currentX+move,0f,0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.TabSystem(this);
    }
    void OnEnable(){
        InterWind.closeTheTab += CheckTabforClose;
    }
    void OnDisable(){
        InterWind.closeTheTab -= CheckTabforClose;
    }

    void CheckTabforClose(int winIndex){
        if(this.transform.GetSiblingIndex() == winIndex){
            DeleteTab();
        }
    }
}
