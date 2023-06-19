using UnityEngine;
using System.Linq;
using System.Collections.Generic;  
using TMPro;


public class Minigame_1 : MonoBehaviour
{
    private Sprite[] fakes;
    private Sprite[] reals;
    private Sprite theReal;
    private Sprite websiteLogo;
    private Sprite btn;
    private TMP_FontAsset pixelFont;
    public int theRealIndex;
    private int numberOfRounds=3;
    private int correctLinks;
    private bool hasEnded = false;
    private System.Random rand;
    private object[] loadedFakeIcons;
    private object[] loadedRealIcons;
    public delegate void GameWon();
    public static event GameWon goToVictory;
    //private Difficulty_Minigame1 difficulty = new Difficulty_Minigame1();
    List<string> listOfReals;
    private string[] realLinks = {"hamilton008796465744234532.mp3",
                                  "tomjones634268543973633245.mp3",
                                  "julioiglesias8521644123974.mp3"};
    /*private string[] realLinks = {"L
                                  "L
                                  "LELE*/
    private string[] fakeLinks = {"hamilton005898215742114532.mp3",
                                  "hamilton008796588746917282.mp3",
                                  "hamilton008796536978734532.mp3",
                                  "hamilton789368752145415365.mp3",
                                  "tomjones634268543975698743.mp3",
                                  "tomjones412395543973633245.mp3",
                                  "tomjones634219738249153245.mp3",
                                  "tomjones336547453951258364.mp3",
                                  "julioiglesias8521647532145.mp3",
                                  "julioiglesias2365494123974.mp3",
                                  "julioiglesias4682319874552.mp3",
                                  "julioiglesias8521671113974.mp3"};
    void Start(){
        //Load Fake download icons
        correctLinks =3;
        loadedFakeIcons = Resources.LoadAll ("Fake_Links",typeof(Sprite)) ;
        fakes = new Sprite[loadedFakeIcons.Length];
        loadedFakeIcons.CopyTo (fakes,0);
        //Load Font
        pixelFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Pixel_Font") as TMP_FontAsset;
        //Load Btn Icon
        btn=Resources.Load<Sprite>("Internet_Browser_2");
        //Load Real download icons
        loadedRealIcons = Resources.LoadAll ("Real_Links",typeof(Sprite)) ;
        reals = new Sprite[loadedRealIcons.Length];
        loadedRealIcons.CopyTo (reals,0);
        rand = new System.Random();
        //Load the Logo of the website
        websiteLogo = Resources.Load("FreeMusic_Logo") as Sprite;
        //Get a list of the True Links
        OrganizeRealLinks();

    }
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
    public string[] LinksRandoOrder(){
        string[] newList = realLinks.Concat(fakeLinks).ToArray();
        newList = newList.OrderBy(x=>rand.Next(0,15)).ToArray();
        return newList;
    }
    public void OrganizeRealLinks(){
        listOfReals= new();
        listOfReals.AddRange(realLinks);
        foreach(string link in realLinks)
            listOfReals.Add(link);
    }
    public List<string> GetRealLinks(){
        return listOfReals;
    }
    public void RoundDone(){
        numberOfRounds=numberOfRounds-1;
    }
    public int GetRounds(){
        return numberOfRounds;
    }
    public void correctLinkClicked(bool safe){
        if(safe)
            correctLinks= correctLinks - 1;
        if(correctLinks == 0)
            goToVictory();
    }
    public int IsGameFinished(){
        return correctLinks;
    }
    public Sprite WebsiteLogo(){
        return websiteLogo;
    }
    public Sprite GetBtn(){
        return btn;
    }
    public TMP_FontAsset GetFont(){
        return pixelFont;
    }
    public bool HasEnded(){
        return hasEnded;
    }
    public void SetEnded(){
        FindObjectOfType<Music_Manager>().Play("Track1-Nivel_Pasado",false);
        hasEnded = true;
    }
}