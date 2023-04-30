using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessageManager : MonoBehaviour
{
    private GameMaster gm;
    public TMP_Text messageText;
    public Queue<string> messages;
    public bool hasended=false;
    private int theDay;
    public bool blockLast=false;
    public delegate void ActivateOptions();
    public static event ActivateOptions showtheOptions;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        messages = new Queue<string>();
        theDay = PlayerPrefs.GetInt("day");
        
    }
    public void StartMessage(Messages anouncement){
        Debug.Log("Mostrando el mensaje deseado");
        blockLast=false;
        messages.Clear();

        foreach (string message in anouncement.messages){
            messages.Enqueue(message);
        }
        DisplayNextMessage();
    }
    public void DisplayNextMessage(){
        //Activate Options on the Minigame 2
        DisplayMinigameOptions();
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
    public void DisplayMinigameOptions(){
        if(messages.Count==1 && theDay==2 && gm.startMinigame2){
            blockLast=true;
            showtheOptions();
        }
    }
    public void EndMessages(){
        Debug.Log("Fin de la conversación");
    }
    public bool Ended(){
        return hasended;
    }
}