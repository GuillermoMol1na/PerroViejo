using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    public Messages message;
    private MessageManager msgManager;
    private GameObject MsgBox;
    private bool showit= false;

    void Start(){
        msgManager = FindObjectOfType<MessageManager>();
        MsgBox = GameObject.FindGameObjectWithTag("MsgBox");
        MsgBox.SetActive(showit);
    }
    void Update(){
        if(showit && Input.GetKeyDown(KeyCode.Space))
            TriggerNextMessage();
    }
    public void TriggerMessage(){
        ActivateMsgBox();
        msgManager.StartMessage(message);
    }
    public void ActivateMsgBox(){
        showit= !showit;
        MsgBox.SetActive(showit);
    }
    public void TriggerNextMessage(){
        msgManager.DisplayNextMessage();
        if(msgManager.Ended()){
            showit= !showit;
            MsgBox.SetActive(showit);
        }
    }
}
