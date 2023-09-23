using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCheck_Script : MonoBehaviour
{
    PrtStageManagerScript stageManager_;
    [SerializeField] GameObject CheckPanel;
    // Start is called before the first frame update
    void Start()
    {
        stageManager_ = GameObject.Find("Main Camera").GetComponent<PrtStageManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("踏みました");
        if (!col.gameObject.CompareTag("Player")) { return; }
        //call Panel
        CheckPanel.SetActive(true);
        /*
        Debug.Log("判定踏みました");
        if(stageManager_.stageOffClearCheck())
        {
            Debug.Log("まだ電源がついています");
        }
        */

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("降りました");
        if (!col.gameObject.CompareTag("Player")) { return; }
        //disable Panel
        CheckPanel.SetActive(false);
    }

}
