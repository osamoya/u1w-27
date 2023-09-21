using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtBallScript : MonoBehaviour
{
    [SerializeField] public Vector2 initPos;
    [SerializeField] int initVector;//(2468)
    [SerializeField] int Vector;//can change....
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void ResetPos()
    {
        transform.position = initPos;
        Vector = initVector;
    }
    private void Awake()
    {
        ResetPos();
    }
    private void move()
    {
        switch (Vector)
        {
            case 2:
                transform.position +=new Vector3(0,-1,0)*Time.deltaTime ;
                break;
            case 4:
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
                break;
            case 6:
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                break;
            case 8:
                transform.position += new Vector3(0,  1, 0) * Time.deltaTime;
                break;
        }
    }
}
