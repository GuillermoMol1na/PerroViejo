using UnityEngine;

[System.Serializable]
public class Messages
{
    [TextArea(1,10)]
    public string[] messages;

    public void Include(string[] themessages){
        messages= themessages;
    }
}
