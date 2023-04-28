using UnityEngine;

public class ExitPC : MonoBehaviour
{
    private GameObject OptionsTab;
    private bool active;
    void Start()
    {
        OptionsTab = GameObject.FindGameObjectWithTag("OptionsTab");
        active=false;
        OptionsTab.SetActive(active);
    }
    public void ShoworHideOptions(){
        Debug.Log("MUESTRA/ESCONDE LA OPCIÓN SALIR");
        active =!active;
        OptionsTab.SetActive(active);
    }
}
