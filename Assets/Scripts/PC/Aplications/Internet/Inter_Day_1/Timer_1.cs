using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    private GameObject internetMinigame;
    private GameObject childText;
    private UniversalAdditionalCameraData cameraData;
    private GameObject background;
    private GameObject[] strikes = new GameObject[3];
    private Music_Manager mm;
    private float timeValue;
    private float refresh;
    public bool isActive;
    private int strikeCounter=0;
    public TMP_Text timerText;
    private float minutes;
    private float seconds;
    private float min;
    private float sec;
    private Difficulty_Minigame1 difficulty = new Difficulty_Minigame1();
    public delegate void GameOver();
    public static event GameOver goToGameOver;
    void Start(){
        cameraData = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UniversalAdditionalCameraData>();
        internetMinigame = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        //Music Manager
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
        timerText.transform.SetAsLastSibling();
        childText = this.transform.GetChild(4).gameObject;
        background = this.transform.GetChild(0).gameObject;
        for(int i =1;i<4;i++){
            strikes[i-1] = this.transform.GetChild(i).gameObject;
        }
        DeactivateTimer();

        //Get the DIFFICULTY OF THE DAY
        switch(PlayerPrefs.GetInt("difficulty")){
            case 0:
                timeValue = difficulty.EasyTime();
            break;
            case 1:
                timeValue = difficulty.MediumTime();
            break;
            case 2:
                timeValue = difficulty.HardTime();
            break;
        }
        refresh = timeValue;
        
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
            GameOverEffect();
            //Restart time
            timeValue=refresh;
        }
        if(timeToDisplay < 11){
            timerText.color = new Color32(255,0,0,255);
        }
         minutes=  Mathf.FloorToInt(timeToDisplay / 60);
         seconds = Mathf.FloorToInt(timeToDisplay % 60);
         min = refresh - minutes;
         sec = refresh - seconds;
         //Save value for results
         PlayerPrefs.SetFloat("minutes",min);
         PlayerPrefs.SetFloat("seconds",sec);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        mm.Play("Track11-Minigame1",true);
        PlayerPrefs.SetInt("strike",0);
        isActive = true;
        //this.gameObject.SetActive(isActive);
        background.SetActive(isActive);
        childText.SetActive(isActive);
    }
    public void DeactivateTimer(){
        mm.Stop("Track11-Minigame1");
        isActive = false;
        for(int i =1;i<4;i++){
            strikes[i-1].SetActive(false);
        }
        childText.SetActive(isActive);
        background.SetActive(isActive);
    }
    public void SetStrike(){
        mm.Play("Track7-Strike",false);
        strikes[strikeCounter].SetActive(true);
        strikeCounter++;
        PlayerPrefs.SetInt("strike",strikeCounter);
        //Game Over for the failure
        if(strikeCounter == 3){
            GameOverEffect();
        }
    }
    private void GameOverEffect(){
            internetMinigame.SetActive(false);
            gameObject.SetActive(false);
            mm.Stop("Track11-Minigame1");
            mm.Play("Track5-PCFallando",true);
            cameraData.renderPostProcessing = true;
            goToGameOver();
    }
    public bool GetActive(){
        return isActive;
    }
}
