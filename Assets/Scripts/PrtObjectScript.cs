using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtObjectScript : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    [SerializeField] bool U;//à⁄ìÆÇ≈Ç´ÇÈÇ©Ç›ÇΩÇ¢Ç»Å®Ç¢ÇÁÇ»Ç¢
    [SerializeField] bool D;
    [SerializeField] bool L;
    [SerializeField] bool R;
    // Start is called before the first frame update
    void Start()
    {
        X=(int)transform.position.x; 
        Y=(int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.W)) { moveObject( 0, 1); }
        if (Input.GetKeyDown(KeyCode.A)) { moveObject(-1, 0); }
        if (Input.GetKeyDown(KeyCode.S)) { moveObject( 0,-1); }
        if (Input.GetKeyDown(KeyCode.D)) { moveObject( 1, 0); }


    }
    public bool canMove(int x,int y)//Ç±ÇÍÇ¢ÇÁÇ»Ç¢Ç©Ç‡
    {
        int dx = X - x;
        int dy = Y - y;
        Vector2 foo = new Vector2(dx, dy);
        Debug.Log("foo="+foo);
        Collider2D hit = Physics2D.OverlapPoint(foo);
        Debug.Log(hit);
        return (hit == null) ? true : false;
     }
    public void moveObject(int x,int y)
    {
        //X += x;
        //Y += y;
        //Vector2 pos;
        //pos = new Vector2(X, Y);
        //transform.position = pos;
    }
    public void moveObject(Vector2 pos)
    {
        X = (int)pos.x;
        Y=(int)pos.y;
        transform.position = pos;
        Debug.Log("object was moved");

    }
}
