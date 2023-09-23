using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckPanel_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ONOFF;
    [SerializeField] TextMeshProUGUI RedBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Btn_Script.getBallNum()==0)
        {
            RedBall.text = "<s>Still red</s>";
        }
        else
        {
            RedBall.text = "Still red";
        }
        if (PrtStageManagerScript.isClear)
        {
            ONOFF.text = "<s>Still ON...</s>";
        }
        else
        {
            ONOFF.text = "Still ON...";
        }
    }
}
