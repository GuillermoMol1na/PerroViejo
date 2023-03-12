using UnityEngine;

public class Minibar : MonoBehaviour
{
    public Sprite GlassFull;
    public Sprite GlassEmpty;
    public Collider2D minibarColl;
    public bool confirm= false;
    private GameMaster  gm;
    private PlayerMovement player;
    [SerializeField] private RedArrowObj redArrow;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player= PlayerMovement.FindObjectOfType<PlayerMovement>();
        if(gm.glassfull)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassFull;
        else{
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassEmpty;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(minibarColl) && Input.GetKeyDown(KeyCode.F) && !confirm){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = GlassEmpty;
            redArrow.RedArrowVanish();
            gm.usedRedArrowBook=false;
            confirm=true;
        }
    }
}
