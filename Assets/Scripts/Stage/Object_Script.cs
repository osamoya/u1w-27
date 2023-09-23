using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object_Script : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    // Start is called before the first frame update
    void Start()
    {
        X = (int)transform.position.x;
        Y = (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveObject(Vector2 pos)
    {
        X = (int)pos.x;
        Y = (int)pos.y;
        transform.DOMove(pos, 0.1f); ;
        
    }
    public bool canMove(int x,int y)
    {
        int dx = X - x;
        int dy = Y - y;
        Vector2 foo = new Vector2(dx, dy);
        
        Collider2D hit = Physics2D.OverlapPoint(foo);
        
        return (hit == null) ? true : false;
    }
}
