using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Email_Manager : MonoBehaviour
{
    private GameObject emailWindow;
    private GameObject emailContent;
    private void Start(){
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailContent = emailWindow.transform.Find("Scroll_Email").transform.Find("Email_Content").gameObject;
        for(int i=0; i<5;i++){
            GameObject email = Instantiate(new GameObject("Generado_"+i.ToString()));
            email.transform.SetParent(emailContent.transform);
        }
    }
}
