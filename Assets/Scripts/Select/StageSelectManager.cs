using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] int row = 3;
    [SerializeField] int col = 2;
    [SerializeField] int selectedStage = 0;
    [SerializeField] Image fadeOverRay;
    [SerializeField] AudioClip select_;
    AudioSource audioSource;

    Selectable[] selects;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Sequence()
            .Append(fadeOverRay.DOFade(1, 0))
            .Append(fadeOverRay.DOFade(0, 1))
        ;

        audioSource = this.GetComponent<AudioSource>();
        selects = GetComponents<Selectable>();
        for(int i=0;i<selects.Length;i++)
        {
            //selects[i].Select();
        }
    }

    // Update is called once per frame
    void Update()
    {
        selectNumber();
        selectButton();
    }
    void selectButton()
    {
        buttons[selectedStage].Select();
    }

    void selectNumber()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            selectedStage++;audioSource.PlayOneShot(select_);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedStage--; audioSource.PlayOneShot(select_);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedStage += row; audioSource.PlayOneShot(select_);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedStage -= row; audioSource.PlayOneShot(select_);
        }
        if (selectedStage < 0) selectedStage += (row*col);
        selectedStage %= (row*col);

    }
}
