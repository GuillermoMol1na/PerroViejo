using UnityEngine;

public class MsgBoxPosition : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3(0,0,-10f);

    void FixedUpdate()
    {
        if(target)
        {
            //Se actualiza el objetivo + el offset
            transform.position = new Vector3(
                target.transform.position.x + offset.x,
                target.transform.position.y + offset.y,
                offset.z
            );
        }
    }
}
