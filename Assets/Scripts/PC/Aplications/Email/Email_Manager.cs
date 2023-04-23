using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Email_Manager : MonoBehaviour
{
    public Sprite emailBckround;
    public Sprite notRead;
    private TMP_FontAsset pixelFont;
    private GameObject emailWindow;
    private GameObject emailContent;
    private GameObject email;
    private GameObject contactTMP;
    private GameObject subjectTMP;
    private GameObject Icon;
    private string [,] emailsOftheDay;
    private int emailLength;
    private EmailBtn_Creation btnEmail = new EmailBtn_Creation();
    private Contact_Subject_Creation subjectAndContact = new Contact_Subject_Creation();
    private Email_Storage eStorage = new Email_Storage();
   private void Start(){
        
        //Locating the parent
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailContent = emailWindow.transform.Find("Scroll_Email").transform.Find("Email_Content").gameObject;
        pixelFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Pixel_Font");
        //Getting the day
        switch(PlayerPrefs.GetInt("day")){
        case 0:
            emailsOftheDay = eStorage.dayZero;
            emailLength=eStorage.getDay0Length();
        break;
        case 1:
            emailsOftheDay = eStorage.dayOne;
            emailLength=eStorage.getDay1Length();
        break;
        case 2:
            emailsOftheDay = eStorage.dayTwo;
            emailLength=eStorage.getDay2Length();
        break;
        }
        //Get email total to the EmailApp
        emailWindow.GetComponent<Email_App>().emailsNeeded = emailLength;

        for(int i=0; i<emailLength;i++){
            //Creating the email
            email =  new GameObject((i).ToString());

            //Adding Text Contact
            contactTMP = subjectAndContact.createCon(pixelFont, i, emailsOftheDay[0,i]);
            contactTMP.transform.SetParent(email.transform);
            subjectTMP = subjectAndContact.createSub(pixelFont, i,emailsOftheDay[1,i]);
            subjectTMP.transform.SetParent(email.transform);
            //Creating the Icon
            Icon = btnEmail.CreateReadorNot(notRead);
            Icon.transform.SetParent(email.transform);
            //Creating whats left of the email
            email = btnEmail.CreateBtn(email, i, emailBckround, emailsOftheDay[2,i], emailsOftheDay[3,i]);
            //Putting the email on the Content Parent
            email.transform.SetParent(emailContent.transform);
        }
    }

}
