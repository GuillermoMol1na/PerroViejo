using UnityEngine;

public class Trash_App : MonoBehaviour
{
   private GameObject trashWindow;
    private bool isActive;
    
    void Start()
    {
        trashWindow = GameObject.FindGameObjectWithTag("TrashWindow");
        isActive = false;
        trashWindow.SetActive(isActive);
    }

    public void OpenTrash(){
        FindObjectOfType<Music_Manager>().Play("Track6-Click",false);
        isActive=!isActive;
        trashWindow.SetActive(isActive);
    }
    public void CloseTrash(){
        FindObjectOfType<Music_Manager>().Play("Track6-Click",false);
        isActive=!isActive;
        trashWindow.SetActive(isActive);
    }
}
