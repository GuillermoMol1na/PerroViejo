using UnityEngine;
using System.Linq;
using System;
using System.Security.Cryptography;   


public class Minigame_1 : MonoBehaviour
{
    private Sprite[] fakes;
    private Sprite[] reals;
    private Sprite[] fakesShuffled;
    private Sprite[] fakeAntivirus;
    private Sprite theReal;
    private Sprite theAntivirus;
    public int theRealIndex;
    private System.Random rand;
    private object[] loadedFakeIcons;
    private object[] loadedRealIcons;
    private object[] loadedFakeAnti;
    void Start(){
        //Load Fake download icons
        loadedFakeIcons = Resources.LoadAll ("Fake_Links",typeof(Sprite)) ;
        fakes = new Sprite[loadedFakeIcons.Length];
        loadedFakeIcons.CopyTo (fakes,0);
        //Load Real download icons
        loadedRealIcons = Resources.LoadAll ("Real_Links",typeof(Sprite)) ;
        reals = new Sprite[loadedRealIcons.Length];
        loadedRealIcons.CopyTo (reals,0);
        rand = new System.Random();
        //Load the Fake Antivirus Icon
        loadedFakeAnti = Resources.LoadAll ("Fake_Antivirus",typeof(Sprite)) ;
        fakeAntivirus = new Sprite[loadedFakeAnti.Length];
        loadedFakeAnti.CopyTo(fakeAntivirus,0);
        //Load the real Antivirus Icon
        theAntivirus = Resources.Load("AntiVirus_Icon") as Sprite;

    }
    /*public Sprite[] FakeSprite(){
        return fakes;
    }
    public Sprite[] RealSprite(){
        return reals;
    }
    public Sprite[] ShuffleFakes(){
        Sprite[] newArray =fakes.OrderBy(x=>rand.Next(0,22)).ToArray();
        return newArray;
    }
    public Sprite RandomTrue(){
        return reals[rand.Next(0,3)];
    }*/
    public Sprite[] Reshuffle(){
    Sprite[] newList = new Sprite[15];
    fakes = fakes.OrderBy(x=>rand.Next(0,22)).ToArray();
    theReal = reals[rand.Next(0,3)];
    int ind = rand.Next(0,15);
        for(int i=0; i<15;i++){
            if(i==ind){
                newList[i]=theReal;
                theRealIndex=i;
            }
            else if(i>ind){
                newList[i]=fakes[i-1];
            }
            else{
                newList[i]=fakes[i];
            }
            
        }
        return newList;
    }
    public Sprite RandomFakeAnti(){
        int rando = rand.Next(0,fakeAntivirus.Length);
        return fakeAntivirus[rando];
    }
    public Sprite RealAnti(){
        return theAntivirus;
    }
}
