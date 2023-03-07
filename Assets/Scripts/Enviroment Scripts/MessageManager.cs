using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public TMP_Text messageText;
    public Queue<string> messages;
    private bool hasended=false;
    // Start is called before the first frame update
    void Start()
    {
        messages = new Queue<string>();
    }
    public void StartMessage(Messages anouncement){
        Debug.Log("Mostrando el mensaje deseado");
        
        messages.Clear();

        foreach (string message in anouncement.messages){
            messages.Enqueue(message);
        }
        DisplayNextMessage();
    }
    public void DisplayNextMessage(){
        if(messages.Count ==0){
            EndMessages();
            hasended=true;
            return;
        }
        string message= messages.Dequeue();
        Debug.Log("Aquí se dbería mostrar el mensaje: " + message);
        messageText.text = message;
    }
    public void EndMessages(){
        Debug.Log("Fin de la conversación");
    }
    public bool Ended(){
        return hasended;
    }
}
