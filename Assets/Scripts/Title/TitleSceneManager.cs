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
    // Start is called before the first frame update
    void Start()
    {
         audioSource= this.GetComponent<AudioSource>();
        fadeOverRay.DOFade(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown&&!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
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

}
