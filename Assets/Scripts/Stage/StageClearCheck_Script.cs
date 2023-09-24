using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCheck_Script : MonoBehaviour
{
    PrtStageManagerScript stageManager_;
    [SerializeField] GameObject CheckPanel;
    [SerializeField] AudioClip in_;
    [SerializeField] AudioClip out_;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        stageManager_ = GameObject.Find("Main Camera").GetComponent<PrtStageManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ì•Ç›Ç‹ÇµÇΩ");
        if (!col.gameObject.CompareTag("Player")) { return; }
        //call Panel
        audioSource.PlayOneShot(in_);
        CheckPanel.SetActive(true);
        /*
        Debug.Log("îªíËì•Ç›Ç‹ÇµÇΩ");
        if(stageManager_.stageOffClearCheck())
        {
            Debug.Log("Ç‹ÇæìdåπÇ™Ç¬Ç¢ÇƒÇ¢Ç‹Ç∑");
        }
        */

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("ç~ÇËÇ‹ÇµÇΩ");
        if (!col.gameObject.CompareTag("Player")) { return; }
        //disable Panel
        audioSource.PlayOneShot(out_);
        CheckPanel.SetActive(false);
    }

}
