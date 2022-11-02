
using UnityEngine;

public class UseDoor : MonoBehaviour
{

    public Collider2D doorColl;
    public void OpenDoor(){
        gameObject.SetActive(false);
    }

}
