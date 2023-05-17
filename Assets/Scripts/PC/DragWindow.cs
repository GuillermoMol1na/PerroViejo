using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private    RectTransform dragRectTransform;
    private Canvas theCanvas;
    private void Awake(){
        if(dragRectTransform == null){
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetSiblingIndex(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        theCanvas = GameObject.FindGameObjectWithTag("CanvasApp").GetComponent<Canvas>();
    }
}
