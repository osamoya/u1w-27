using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCheck_Script : MonoBehaviour
{
    PrtStageManagerScript stageManager_;
    // Start is called before the first frame update
    void Start()
    {
        stageManager_ = GameObject.Find("MainCamera").GetComponent<PrtStageManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //call Panel
        
        /*
        Debug.Log("判定踏みました");
        if(stageManager_.stageOffClearCheck())
        {
            Debug.Log("まだ電源がついています");
        }
        */

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //disable Panel
    }

}
