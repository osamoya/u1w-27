using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrtBtnScript : MonoBehaviour
{
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
    }
}
