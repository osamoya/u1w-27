using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] string title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown&&!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            loadScene();
        }
    }

    private void loadScene()
    {
        SceneManager.LoadScene(title);
    }

}
