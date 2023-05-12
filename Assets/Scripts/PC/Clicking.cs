using UnityEngine.EventSystems;
using UnityEngine;

public class Clicking : MonoBehaviour, IPointerClickHandler
{
    private Music_Manager mm;
    void Start(){
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
        }
    public void OnPointerClick(PointerEventData eventData)
    {
        mm.Play("Track6-Click",false);
    }
}
