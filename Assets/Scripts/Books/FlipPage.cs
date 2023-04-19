using UnityEngine;
using TMPro;

public class FlipPage : MonoBehaviour
{
    private TMP_Text titles;
    public TMP_Text theText;
    private string theTitle;
    private string[] informationOftheDay;
    private int infoSize;
    private int index=0;
    private BookStorage theStorage = new BookStorage();
    void Start(){
        titles = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); 
        theText = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        switch(PlayerPrefs.GetInt("day")){
            case 0:
                theTitle = theStorage.titles[0];
                informationOftheDay = theStorage.day0;
            break;
            case 1:
                theTitle = theStorage.titles[1];
                informationOftheDay = theStorage.day1;
            break;
            case 2:
                theTitle = theStorage.titles[2];
                informationOftheDay = theStorage.day2;
            break;
        }
        infoSize = informationOftheDay.Length;
        //Show the Title and initial Text
        titles.text = theTitle;
        theText.text = informationOftheDay[0]; 
    }
    public void PreviousPage(){
        index--;
        if(index < 0){
            index=infoSize-1;
            theText.text = informationOftheDay[index]; 
        }
        else{
            theText.text = informationOftheDay[index]; 
        }
    }
    public void NextPage(){
        index++;
        if(index >= infoSize){
            index=0;
            theText.text = informationOftheDay[index]; 
        }
        else{
            theText.text = informationOftheDay[index]; 
        }
    }
}
