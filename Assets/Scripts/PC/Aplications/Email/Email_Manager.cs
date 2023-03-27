using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Email_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text emailText;
    public Queue<string> emails;
    private bool hasended=false;
    // Start is called before the first frame update
    void Start()
    {
        emails = new Queue<string>();
    }
    public void StartMessage(Email_Storage anouncement){
        Debug.Log("Mostrando el mensaje deseado");
        
        emails.Clear();

        foreach (string email in anouncement.theEmails){
            emails.Enqueue(email);
        }
        DisplayNextemail();
    }
    public void DisplayNextemail(){
        if(emails.Count ==0){
            Endemails();
            hasended=true;
            return;
        }
        string email= emails.Dequeue();
        Debug.Log("Aquí se dbería mostrar el mensaje: " + email);
        emailText.text = email;
    }
    public void Endemails(){
        Debug.Log("Fin de la conversación");
    }
    public bool Ended(){
        return hasended;
    }
}
