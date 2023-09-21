using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtBallScript2 : MonoBehaviour
{
    [SerializeField] GameObject ball2;
    [SerializeField] GameObject ball4;
    [SerializeField] GameObject ball6;
    [SerializeField] GameObject ball8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void ResetPos()
    {
        Debug.Log("球の位置をリセットします");
        ball2.transform.localPosition = new Vector3(0, -0.25f, 0);
        ball4.transform.localPosition = new Vector3(-0.25f, 0, 0);
        ball6.transform.localPosition = new Vector3( 0.25f, 0, 0);
        ball8.transform.localPosition = new Vector3(0,  0.25f, 0);
    }
    private void OnEnable()
    {
        ResetPos();
        ball2.gameObject.SetActive(true);
        ball4.gameObject.SetActive(true);
        ball6.gameObject.SetActive(true);
        ball8.gameObject.SetActive(true);

    }
    private void OnDisable()
    {
        ResetPos();
        ball2.gameObject.SetActive(false);
        ball4.gameObject.SetActive(false);
        ball6.gameObject.SetActive(false);
        ball8.gameObject.SetActive(false);
    }
    private void move()
    {
        ball2.transform.position += new Vector3( 0, -1, 0) * Time.deltaTime;
        ball4.transform.position += new Vector3(-1,  0, 0) * Time.deltaTime;
        ball6.transform.position += new Vector3( 1,  0, 0) * Time.deltaTime;
        ball8.transform.position += new Vector3( 0,  1, 0) * Time.deltaTime;
    }
}
