using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtAppliancesScript : MonoBehaviour
{
    [SerializeField]private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigggerEnter2D(Collision2D col)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            Debug.Log("éÛêM");
            isOn = !isOn;
            if (!isOn) { PrtStageManagerScript.AddOffNum(); } else { PrtStageManagerScript.DecrementOffNum(); }
        }
    }

}
