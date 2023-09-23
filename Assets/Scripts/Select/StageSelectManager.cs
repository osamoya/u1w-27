using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] int row = 3;
    [SerializeField] int col = 2;
    [SerializeField] int selectedStage = 0;
    

    Selectable[] selects;
    // Start is called before the first frame update
    void Start()
    {
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
            selectedStage++;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedStage--;
            
        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedStage += row;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedStage -= row;
        }
        if (selectedStage < 0) selectedStage += (row*col);
        selectedStage %= (row*col);

    }
}
