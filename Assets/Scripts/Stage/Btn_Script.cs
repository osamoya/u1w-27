using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Script : MonoBehaviour
{
    [SerializeField] GameObject balls;
    [SerializeField] private Sprite OFF_s;
    [SerializeField] private Sprite ON_s;
    [SerializeField] public bool isPower;
    float time;
    SpriteRenderer spriteRenderer;
    static int ballNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPower)
        {
            time += Time.deltaTime;
            if (time >= 0.5f) {
                spriteRenderer.sprite = OFF_s;
                isPower = false;
            }
        }
    }
    public void switchPower()
    {
        isPower = true;
        spriteRenderer.sprite = ON_s;
        ballNum += 4;
        Instantiate(balls, transform.position, Quaternion.identity);
    }
    public  static void ReduceBall()
    {
        ballNum--;
    }
    public static int getBallNum()
    {
        return ballNum;
    }
}
