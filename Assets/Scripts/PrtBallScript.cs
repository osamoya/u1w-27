using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtBallScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigerEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall")|| collision.gameObject.CompareTag("object")|| collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Btn_Script.ReduceBall();
        }
    }

}
