using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrtBtnScript : MonoBehaviour
{
    [SerializeField] GameObject ball2;
    [SerializeField] GameObject ball4;
    [SerializeField] GameObject ball6;
    [SerializeField] GameObject ball8;
    [SerializeField] GameObject balls;
    [SerializeField] public bool isPower;
    [SerializeField] private Sprite OFF_s;
    [SerializeField] private Sprite ON_s;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) { switchPower(); }
    }

    public void switchPower()
    {
        isPower = !isPower;

        spriteRenderer.sprite = (isPower) ? ON_s : OFF_s;
        
        if (isPower)
        {/*
            ball2.gameObject.SetActive(true);
            ball4.gameObject.SetActive(true);
            ball6.gameObject.SetActive(true);
            ball8.gameObject.SetActive(true);
            balls.gameObject.SetActive(true);*/
            Instantiate(balls, transform.position, Quaternion.identity);
        }
        else
        {
            //balls.gameObject.SetActive(false);
        }
        
    }
}
