using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_1 : MonoBehaviour
{
    public string nombre;
    void Start(){
        Sprite[] fake;
        object[] loadedIcons = Resources.LoadAll ("Fake_Links",typeof(Sprite)) ;
        fake = new Sprite[loadedIcons.Length];
        loadedIcons.CopyTo (fake,0);
        
        foreach( Sprite spri in fake)
        {
            Debug.Log(spri.name);
        }
        Debug.Log("HOLA");
    }
}
