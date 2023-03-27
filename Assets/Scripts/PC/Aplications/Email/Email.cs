using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Email : MonoBehaviour
{
    private GameObject emailWindow;
    private GameObject emailContent;
    private string title;
    public TMP_Text titleEmail;
    public TMP_Text contentEmail;
    public delegate void ShowEmail(string thecontact);
    public static event ShowEmail showEmail;
    
    void Start(){
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailContent = this.transform.parent.parent.gameObject;
        titleEmail = this.transform.Find("TextContact").gameObject.GetComponent<TMP_Text>();
    }
    public void OpenEmail(){
        emailContent.SetActive(false);
        if(showEmail != null){
            showEmail(titleEmail.text);
        }
    }
}
