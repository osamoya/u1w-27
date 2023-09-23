using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object_Script : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    [SerializeField] private bool IsMoveable;
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
    public bool GetIsMoveable() { return IsMoveable; }
}
