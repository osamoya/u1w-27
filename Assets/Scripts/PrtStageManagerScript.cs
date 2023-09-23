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
        Debug.Log("Ç±ÇÃïîâÆÇ…â∆ìdÇÕ"+appNum);
        offNum = 0;
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stageClearCheck()) { Debug.Log("èIóπÅI"); }
        //Debug.Log("èÛãµÅF" + offNum);
        if (isClear) { setPanel(); }
    }

    public bool stageOffClearCheck()
    {
        if (offNum < appNum) { return false; }
        return true;
    }

    public static void AddOffNum()
    {
        Debug.Log("àÍå¬è¡Ç¶Ç‹ÇµÇΩ");
        offNum++;
        if (offNum < appNum) { return; } else { Debug.Log("Å`Å`Å`èIóπÅ`Å`Å`"); isClear = true; return; }
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
