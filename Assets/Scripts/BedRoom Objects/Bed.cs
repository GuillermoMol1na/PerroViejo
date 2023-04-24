using UnityEngine;

public class Bed : MonoBehaviour
{
    public Sprite bedMade;
    public Sprite bedUnmade;
    public Collider2D bedColl;
    public bool confirm= false;
    private GameMaster  gm;
    private MessageTrigger msgTrigg;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private RedArrowObj redArrow;
    private string[] confirmSave = {"¿Deseas Guardar la partida?"};
    private string[] acceptSave = {"Partida Guardada"};
    private Messages mkBedMsg = new Messages();
    public delegate void SelectOptions();
    public static event SelectOptions showTheOptions;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        mkBedMsg.Include(confirmSave);
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        if(gm.BedMade)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
        else
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedUnmade;
    }
    private void showtheAcceptMessages(){
        mkBedMsg.Include(acceptSave);
        msgTrigg.UsetheMessages(mkBedMsg);
        msgTrigg.TriggerMessage();
    }
    void Update()
    {
        if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F) && !confirm){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
            redArrow.RedArrowVanish();
            confirm=true;
        }else if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F) && confirm){
            //GUARDAR PARTIDA y usar PlayerPrefabs para reiniciar glass y demás en GameMaster
            msgTrigg.UsetheMessages(mkBedMsg);
            msgTrigg.TriggerMessage();
            showTheOptions();

            PlayerPrefs.SetInt("day",1);
        }
    }
        void OnEnable(){
        Options_Answers.showAccept += showtheAcceptMessages;
    }
    void OnDisable(){
        Options_Answers.showAccept -= showtheAcceptMessages;
    }

}
