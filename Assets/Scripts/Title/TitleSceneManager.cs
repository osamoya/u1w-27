using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] string title;
    [SerializeField] Image fadeOverRay;
    [SerializeField] AudioClip fadeOutRay;
    AudioSource audioSource;
    [SerializeField] GameObject Rmcn_OFF;
    [SerializeField] GameObject Rmcn_ON;
    [SerializeField] GameObject Light_OFF;
    [SerializeField] GameObject Light_ON;
    [SerializeField] GameObject TV_OFF;
    [SerializeField] GameObject TV_ON;
    // Start is called before the first frame update
    void Start()
    {
         audioSource= this.GetComponent<AudioSource>();
        fadeOverRay.DOFade(0,0);
        setLight(true);
        setTV(true);
        setRmcn(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown&&!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            DoOP();
            fadeTitle();
            DOVirtual.DelayedCall(1,()=> loadScene());
            
        }
    }

    private void loadScene()
    {
        SceneManager.LoadScene(title);
    }
    private void fadeTitle()
    {
        
        
        audioSource.PlayOneShot(fadeOutRay);
        fadeOverRay.DOFade(1,0.2f);
    }
    private void DoOP()
    {
        audioSource.PlayOneShot(fadeOutRay);
        //ÉäÉÇÉRÉìïœçX
        setRmcn(true);
        //óºòeçÌèú
        DOVirtual.DelayedCall(1, () => setTV(false));
        DOVirtual.DelayedCall(0, () => setLight(false));
        //ÉäÉÇÉRÉìïœçX
        setRmcn(false);
        //à√ì]

    }
    private void setRmcn(bool b)
    {
        if (b)
        {
            Rmcn_OFF.SetActive(false);
            Rmcn_ON.SetActive(true);
        }
        else
        {
            Rmcn_OFF.SetActive(true);
            Rmcn_ON.SetActive(false);
        }
    }
    private void setTV(bool b)
    {
        if (b)
        {
            TV_OFF.SetActive(false);
            TV_ON.SetActive(true);
        }
        else
        {
            TV_OFF.SetActive(true);
            TV_ON.SetActive(false);
        }
    }
    private void setLight(bool b)
    {
        if (b)
        {
            Light_OFF.SetActive(false);
            Light_ON.SetActive(true);
        }
        else
        {
            Light_OFF.SetActive(true);
            Light_ON.SetActive(false);
        }
    }
}
