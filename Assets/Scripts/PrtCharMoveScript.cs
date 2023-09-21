using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PrtCharMoveScript : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;

    Vector2 next;
    Vector2 nextnext;

    // Start is called before the first frame update
    void Start()
    {
        next=new Vector2 (X,Y);
        nextnext = next;//not good...
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { X -= 1; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { X += 1; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Y += 1; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { Y -= 1; }
        */
        if (Input.anyKeyDown) { move(); }
        if (Input.GetKeyDown(KeyCode.Return)){ switchButton(); }
        //Debug.Log("今の正面は：" + next);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        bool canMove=col.gameObject.GetComponent<PrtObjectScript>().canMove(X, Y);
        if (canMove) { }
    }
    void move()
    {
        //get input
        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow)) { Debug.Log("input is not Arrow"); return ; }
        next = new Vector2(X, Y);
        nextnext = next;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { next.x--;nextnext.x = next.x - 1; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { next.x++; nextnext.x = next.x + 1; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { next.y++; nextnext.y = next.y + 1; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { next.y--; nextnext.y = next.y - 1; }
        //check next
        bool isnext = checkObject(next);
        //check nextnext
        bool isnextnext = checkObject(nextnext);
        //do move
        if (isnext && isnextnext)
        {
            Debug.Log("can't move!");
            return;
        }
        if (isnext)
        {
            Collider2D objectPos = Physics2D.OverlapPoint(next);
            objectPos.gameObject.GetComponent<PrtObjectScript>().moveObject(nextnext);
        }
        transform.position = next;
        X = (int)next.x;
        Y = (int)next.y;
        next = nextnext;
        Debug.Log("今の正面は：" + next);
        /*
        int x= X;
        int y=Y;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { x+=-1; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {x += 1; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { y+=1; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { y += -1; }
        if (checkObject(x, y))
        {
            Debug.Log("cantMove");
        }
        else
        {
            X=x; Y=y;
            Vector2 pos;
            pos = new Vector2(X, Y);
            transform.position = pos;
        }
        */
    }
    
    bool checkObject(Vector2 pos)
    {
        Collider2D hit = Physics2D.OverlapPoint(pos);
        if (hit == null || hit.gameObject.CompareTag("ball")) return false;
        return true;
    }

    bool checkObject(int x,int y)//調べたい座標．これは，単にそこにものがあるかだけで良い
    {
        
        Vector2 next = new Vector2(x, y);
        Debug.Log("調べるのは" + next);
        Collider2D hit = Physics2D.OverlapPoint(next);
        if (hit == null||hit.gameObject.CompareTag("ball"))
        {
            Debug.Log("目の前に何もないので動きます");
            return false;
        }
        Debug.Log("ものがある！");
        
        //
        x *= 2;
        y *= 2;
        Vector2 nextnext = new Vector2(x, y);
        Debug.Log("調べるのは" + nextnext);
        hit = Physics2D.OverlapPoint(nextnext);
        if (hit == null||hit.gameObject.CompareTag("ball")) return false;
        else
        {
            Debug.Log("2個先もダメです");
            return true;
        }
    }

    private void switchButton()
    {
        Debug.Log(next + "にボタンがあるかどうか調べます");
        Collider2D nextPos = Physics2D.OverlapPoint(next);
        Debug.Log("そこにあるのは，"+nextPos);
        if (nextPos == null) { return; }
        PrtBtnScript prtBtnScript=nextPos.gameObject.GetComponent<PrtBtnScript>();
        if (prtBtnScript == null) { Debug.Log("目の前の場所："+next+"にボタンはないよ？");return; }
        prtBtnScript.switchPower();

    }
}
