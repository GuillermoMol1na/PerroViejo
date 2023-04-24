using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessageManager : MonoBehaviour
{
    public TMP_Text messageText;
    public Queue<string> messages;
    public bool hasended=false;
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
        }else{
            string message= messages.Dequeue();
            messageText.text = message;
            Debug.Log("Aquí se dbería mostrar el mensaje: " + message);
        }
        
    }
    public void EndMessages(){
        Debug.Log("Fin de la conversación");
    }
    public bool Ended(){
        return hasended;
    }
}