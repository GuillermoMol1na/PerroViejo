using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    private GameObject child;
    private GameObject[] strikes = new GameObject[3];
    private float timeValue = 90;
    private bool isActive;
    private int strikeCounter=0;
    public TMP_Text timerText;
    public delegate void GameOver();
    public static event GameOver goToGameOver;
    void Start(){
        isActive = true;
        timerText.transform.SetAsLastSibling();
        child = this.transform.GetChild(3).gameObject;
        for(int i =0;i<3;i++){
            strikes[i] = this.transform.GetChild(i).gameObject;
            strikes[i].SetActive(false);
        }
        DeactivateTimer();
    }
    void Update()
    {
        if(timeValue>0){
            timeValue -= Time.deltaTime;
        }else{
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay=0;
            DeactivateTimer();
            //Time Over->Game Over
            goToGameOver();
        }
        if(timeToDisplay < 11){
            timerText.color = new Color32(255,0,0,255);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        isActive = !isActive;
        child.SetActive(isActive);
        this.gameObject.SetActive(isActive);
    }
    public void DeactivateTimer(){
        Debug.Log("Y SE DESACTIVA EL TEMPORIZADOR");
        isActive = false;
        child.SetActive(isActive);
        this.gameObject.SetActive(isActive);
    }
    public void SetStrike(){
        strikes[strikeCounter].SetActive(true);
        strikeCounter=strikeCounter+1;
        //Game Over for the failure
        if(strikeCounter == 3){
            goToGameOver();
        }
    }
    public bool GetActive(){
        return isActive;
    }
    void OnEnable(){
        InterWind.activateTimer += ActivateTimer;
        InterWind.deactivateTimer += DeactivateTimer;
        InterWind.setTheStrike += SetStrike;
    }
    void OnDisable(){
        InterWind.setTheStrike -= SetStrike;
    }

}
