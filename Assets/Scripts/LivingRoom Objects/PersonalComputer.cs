using UnityEngine;


public class PersonalComputer : MonoBehaviour
{

    public Collider2D PcColl;
    private Collider2D playerCol;
    private GameMaster  gm;
    private LevelLoader2 thelevelLoader;
    [SerializeField] private RedArrowObj redArrow;
    private MessageTrigger msgTrigg;
    //This is new
    private string[] readMssg = {"Debes leer acerca de los peligros del malware primero"};
    private string[] drinkMssg = {"Erwin no inicia el día sin un buen vaso de brandy"};
    
    private Messages readMsg = new Messages();
    private Messages drinkMsg = new Messages();
 
    void Start()
    {
        readMsg.Include(readMssg);
        drinkMsg.Include(drinkMssg);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
       if(gm.usedRedArrowPC){
            gm.usedRedArrowPC=true;
            redArrow.RedArrowVanish();
        }
        else{
            redArrow.RedArrowAppear();
        }
    }
    void Update(){
        if(playerCol.IsTouching(PcColl) && Input.GetKeyDown(KeyCode.F) && !gm.startMinigame2){
            if(gm.glassfull){
                msgTrigg.UsetheMessages(drinkMsg);
                msgTrigg.TriggerMessage();
            }
            else if(gm.usedRedArrowPC){
                msgTrigg.UsetheMessages(readMsg);
                msgTrigg.TriggerMessage();
            }else
             thelevelLoader.LoadPC();
             gm.usedRedArrowPC=true;;
             redArrow.RedArrowVanish();
        }
    }

}
