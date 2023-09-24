using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class CheckPanel_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ONOFF;
    [SerializeField] TextMeshProUGUI RedBall;
    [SerializeField] TextMeshProUGUI End;
    [SerializeField] bool noBall;
    [SerializeField] bool noON;
    [SerializeField] GameObject ClearPanel;
    [SerializeField] Image fadeOverRay;
    [SerializeField] AudioClip fadeOutRay;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        ClearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Btn_Script.getBallNum()==0)
        {
            RedBall.text = "<s>�Ԃ��ʂ𕔉��̒��Ɏc���Ȃ�</s>";
            noBall = true;
        }
        else
        {
            RedBall.text = "�Ԃ��ʂ𕔉��̒��Ɏc���Ȃ�";
            noBall = false;
        }
        if (PrtStageManagerScript.isClear)
        {
            ONOFF.text = "<s>�������̓d������Ԃ���</s>";
            noON = true;
        }
        else
        {
            ONOFF.text = "�������̓d������Ԃ���";
            noON = false;
        }
        if (noBall&&noON)
        {
            End.text = "�����肠!";
        }
        else
        {
            End.text = "�����ǂ�";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if (noBall && noON)
            {
                ClearPanel.SetActive(true);
            }
            else
            {
                audioSource.PlayOneShot(fadeOutRay);
                fadeOverRay.DOFade(1, 0.2f);
                DOVirtual.DelayedCall(1, () => SceneManager.LoadScene("SelectScene"));
                
            }
            
        }
        

    }
}
