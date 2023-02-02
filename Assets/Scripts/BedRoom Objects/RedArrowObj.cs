using UnityEngine;

public class RedArrowObj : MonoBehaviour
{
    public bool active;
    public void RedArrowVanish(){
        gameObject.SetActive(false);
    }
    void Start(){
        if(!active)
            RedArrowVanish();
    }
}
