using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerMove_Script : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    [SerializeField] int easeNum;
    [SerializeField] Sprite UP;
    [SerializeField] Sprite DOWN;
    [SerializeField] Sprite LEFT;
    [SerializeField] Sprite RIGHT;
    Vector2 next;
    Vector2 nextnext;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        next = new Vector2(X, Y);
        nextnext = next;//not good...
        
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            DontMove();
            return;
        }
        if (isnext)
        {
            Collider2D objectPos = Physics2D.OverlapPoint(next);
            if (!objectPos.gameObject.GetComponent<Object_Script>().GetIsMoveable())
            {
                DontMove();
                Debug.Log("XXX");
                return;
            }
            objectPos.gameObject.GetComponent<Object_Script>().moveObject(nextnext);
        }
        
        {
            //transform.position = next;
            transform.DOMove(next, 0.5f).SetEase(Ease.OutQuart);//(Ease)easeNum);//Ease.
        //Ease.q
        X = (int)next.x;
        Y = (int)next.y;
        next = nextnext;
        }
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
    void DontMove()
    {
        Vector2 now = new Vector2(X, Y);
        int t = 8;
        Vector2 p = (t * now + (10-t) * next)/10;
        DG.Tweening.Sequence s = DOTween.Sequence();
        s.Append(
            transform.DOMove(p, 0.1f)
            );
        s.Append(
            transform.DOMove(now, 0.2f)
            );

    }

    void changeDirection(int d)
    {
        switch (d)
        {
            case 8:
                spriteRenderer.sprite = UP;
                break;
            case 2: spriteRenderer.sprite = DOWN;
                break;
            case 4:
                spriteRenderer.sprite = LEFT;
                break;
            case 6:
                spriteRenderer.sprite = RIGHT;
               break;
            default: return;
        }
        return ;
    }

}
