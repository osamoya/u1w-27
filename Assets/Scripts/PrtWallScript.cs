using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("�ǂɏՓˁI");
        if (col.gameObject.CompareTag("ball")) { col.gameObject.SetActive(false); }
        
    }

}
