using UnityEngine;

public class InterWind : MonoBehaviour
{
    public TabGroup tabGroup;
    void Start()
    {
        this.gameObject.SetActive(false);
        tabGroup.WindowSystem(this.gameObject);
    }
    public void DeleteWind(){
        //tabGroup.RemoveObject(this.gameObject);
        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
