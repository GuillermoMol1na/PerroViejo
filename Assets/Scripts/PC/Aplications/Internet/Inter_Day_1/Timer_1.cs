using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    private GameObject childText;
    private GameObject background;
    private GameObject[] strikes = new GameObject[3];
    private float timeValue = 90;
    private bool isActive;
    private int strikeCounter=0;
    public TMP_Text timerText;
    public delegate void GameOver();
    public static event GameOver goToGameOver;
    void Start(){
        Debug.Log("EL TEMPORIZADOR VIVE");

        timerText.transform.SetAsLastSibling();
        childText = this.transform.GetChild(4).gameObject;
        background = this.transform.GetChild(0).gameObject;
        Debug.Log("Esto no debería ser NULL: "+ childText.name);
        for(int i =1;i<4;i++){
            strikes[i-1] = this.transform.GetChild(i).gameObject;
        }
        DeactivateTimer();
    }
    void Update()
    {
        if(isActive){
            if(timeValue>0){
                timeValue -= Time.deltaTime;
            }else{
                timeValue = 0;
            }
            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay=0;
            //Time Over->Game Over
            goToGameOver();
            //Restart time
            timeValue=90;
        }
        if(timeToDisplay < 11){
            timerText.color = new Color32(255,0,0,255);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        isActive = true;
        //this.gameObject.SetActive(isActive);
        background.SetActive(isActive);
        childText.SetActive(isActive);
    }
    public void DeactivateTimer(){
        isActive = false;
        for(int i =1;i<4;i++){
            strikes[i-1].SetActive(false);
        }
        childText.SetActive(isActive);
        background.SetActive(isActive);
    }
    public void SetStrike(){
        strikes[strikeCounter].SetActive(true);
        strikeCounter++;
        //Game Over for the failure
        if(strikeCounter == 3){
            goToGameOver();
        }
    }
    public bool GetActive(){
        return isActive;
    }
}
