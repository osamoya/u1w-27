using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtStageManagerScript : MonoBehaviour
{
    PrtAppliancesScript[] appliancesScripts;
    public static int appNum;
    public static int offNum;
    public static bool isClear;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        appliancesScripts=FindObjectsOfType<PrtAppliancesScript>();
        appNum=appliancesScripts.Length;
        Debug.Log("���̕����ɉƓd��"+appNum);
        offNum = 0;
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stageClearCheck()) { Debug.Log("�I���I"); }
        //Debug.Log("�󋵁F" + offNum);
        if (isClear) { setPanel(); }
    }

    public bool stageOffClearCheck()
    {
        if (offNum < appNum) { return false; }
        return true;
    }

    public static void AddOffNum()
    {
        Debug.Log("������܂���");
        offNum++;
        if (offNum < appNum) { return; } else { Debug.Log("�`�`�`�I���`�`�`"); isClear = true; return; }
    }
    public static void DecrementOffNum()
    {
        offNum--;
        if (offNum < 0) {offNum = 0;}
    }
    private void setPanel()
    {
        panel.SetActive(true);
    }
}
