using UnityEngine;

public class RedArrowObj : MonoBehaviour
{
    public bool active;
    public void RedArrowVanish(){
        gameObject.SetActive(false);
    }
    public void RedArrowAppear(){
        gameObject.SetActive(true);
    }
    void Start(){
        if(!active)
            RedArrowVanish();
    }
}
