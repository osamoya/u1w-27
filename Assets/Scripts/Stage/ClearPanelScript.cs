using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ClearPanelScript : MonoBehaviour
{
    [SerializeField] Image fadeOverRay;
    [SerializeField] string nextSceneName;
    [SerializeField] AudioClip tada_;
    [SerializeField] AudioClip next_;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(tada_);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            fadePanel();
            DOVirtual.DelayedCall(1, () => loadScene());
            
        }
    }

    void fadePanel()
    {
        audioSource.PlayOneShot(next_);
        fadeOverRay.DOFade(1, 0.2f);

    }
    private void loadScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
