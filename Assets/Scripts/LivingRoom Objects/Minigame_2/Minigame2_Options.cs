using UnityEngine;

public class Minigame2_Options : MonoBehaviour
{
    private bool isActive;
    private GameObject firstOption;
    private GameObject secondOption;
    void Start(){
        isActive = true;
        firstOption = transform.GetChild(0).gameObject;
        secondOption = transform.GetChild(1).gameObject;

        ShowHideOptions();
    }
    public void ShowHideOptions(){
        isActive = !isActive;
        firstOption.SetActive(isActive);
        secondOption.SetActive(isActive);
    }
    void OnEnable(){
        MessageManager.showtheOptions += ShowHideOptions;
    }
    void OnDisable(){
        MessageManager.showtheOptions -= ShowHideOptions;
    }
}
