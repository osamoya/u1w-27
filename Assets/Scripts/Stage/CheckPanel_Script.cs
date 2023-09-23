using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CheckPanel_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ONOFF;
    [SerializeField] TextMeshProUGUI RedBall;
    [SerializeField] TextMeshProUGUI End;
    [SerializeField] bool noBall;
    [SerializeField] bool noON;
    [SerializeField] GameObject ClearPanel;
    // Start is called before the first frame update
    void Start()
    {
        ClearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Btn_Script.getBallNum()==0)
        {
            RedBall.text = "<s>Still red</s>";
            noBall = true;
        }
        else
        {
            RedBall.text = "Still red";
            noBall = false;
        }
        if (PrtStageManagerScript.isClear)
        {
            ONOFF.text = "<s>Still ON...</s>";
            noON = true;
        }
        else
        {
            ONOFF.text = "Still ON...";
            noON = false;
        }
        if (noBall&&noON)
        {
            End.text = "Å´Clear!";
        }
        else
        {
            End.text = "Å´back to stageSelect";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if (noBall && noON)
            {
                ClearPanel.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("SelectScene");
            }
            
        }
        

    }
}
