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
        if (collision.gameObject.CompareTag("wall")) { gameObject.SetActive(false); }
        if (collision.gameObject.CompareTag("object")) { Debug.Log("‹…‚ª•¨‚É“–‚½‚è‚Ü‚µ‚½"); gameObject.SetActive(false); }
    }

}
