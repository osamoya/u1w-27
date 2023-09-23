using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtStageManagerScript : MonoBehaviour
{
    PrtAppliancesScript[] appliancesScripts;
    public static int appNum;
    public static int offNum;
    // Start is called before the first frame update
    void Start()
    {
        appliancesScripts=FindObjectsOfType<PrtAppliancesScript>();
        appNum=appliancesScripts.Length;
        Debug.Log("���̕����ɉƓd��"+appNum);
        offNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stageClearCheck()) { Debug.Log("�I���I"); }
        //Debug.Log("�󋵁F" + offNum);
    }

    bool stageClearCheck()
    {
        if (offNum < appNum) { return false; }
        return true;
    }

    public static void AddOffNum()
    {
        Debug.Log("������܂���");
        offNum++;
        if (offNum < appNum) { return; } else { Debug.Log("�`�`�`�I���`�`�`"); return; }
    }
    public static void DecrementOffNum()
    {
        offNum--;
        if (offNum < 0) {offNum = 0;}
    }
}
