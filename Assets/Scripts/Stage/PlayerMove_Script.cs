using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Script : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    Vector2 next;
    Vector2 nextnext;
    // Start is called before the first frame update
    void Start()
    {
        next = new Vector2(X, Y);
        nextnext = next;//not good...
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { move(); }
        if (Input.GetKeyDown(KeyCode.Return)) { switchButton(); }
    }
    void move()
    {
        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow)) { return; }
        next = new Vector2(X, Y);
        nextnext = next;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { next.x--; nextnext.x = next.x - 1; }
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
    
    }
    bool checkObject(Vector2 pos)
    {
        Collider2D hit = Physics2D.OverlapPoint(pos);
        if (hit == null || hit.gameObject.CompareTag("ball")) return false;
        return true;
    }
    private void switchButton()
    {
        Collider2D nextPos = Physics2D.OverlapPoint(next);
     
        if (nextPos == null) { return; }
        PrtBtnScript prtBtnScript = nextPos.gameObject.GetComponent<PrtBtnScript>();
        if (prtBtnScript == null) { return; }
        prtBtnScript.switchPower();

    }
}
