using UnityEngine;

public class PersonalComputer : MonoBehaviour
{

    public Collider2D PcColl;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private RedArrowObj redArrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(PcColl) && Input.GetKeyDown(KeyCode.F)){
            
            redArrow.RedArrowVanish();
        }
    }
}
