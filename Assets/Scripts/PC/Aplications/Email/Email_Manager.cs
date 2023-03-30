using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Email_Manager : MonoBehaviour
{
    public Sprite emailBckround;
    public Sprite notRead;
    public Sprite isRead;
    public TMP_FontAsset pixelFont;
    private GameObject emailWindow;
    private GameObject emailContent;
    private GameObject email;
    private GameObject contactTMP;
    private GameObject subjectTMP;
    private GameObject Icon;
    private EmailBtn_Creation btnEmail = new EmailBtn_Creation();
    private Contact_Subject_Creation subjectAndContact = new Contact_Subject_Creation();
    
    private string[] contacts;
   private void Start(){
        
        //Locating the parent
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailContent = emailWindow.transform.Find("Scroll_Email").transform.Find("Email_Content").gameObject;
        //
        for(int i=0; i<5;i++){
            //Creating the email
            email =  new GameObject((5+i).ToString());

            //Adding Text Contact
            contactTMP = subjectAndContact.createCon(pixelFont, i);
            contactTMP.transform.SetParent(email.transform);
            subjectTMP = subjectAndContact.createSub(pixelFont, i);
            subjectTMP.transform.SetParent(email.transform);
            //Creating the Icon
            Icon = btnEmail.CreateReadorNot(notRead);
            Icon.transform.SetParent(email.transform);
            //Creating whats left of the email
            email = btnEmail.CreateBtn(email, i, emailBckround);
            //Putting the email on the Content Parent
            email.transform.SetParent(emailContent.transform);
        }
    }

}
