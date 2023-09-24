using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtAppliancesScript : MonoBehaviour
{
    [SerializeField]private bool isOn;
    [SerializeField] Sprite ON_s;
    [SerializeField] Sprite OFF_s;
    SpriteRenderer sprite;
    [SerializeField] AudioClip ONOFF_;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isOn = true;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = (isOn) ? ON_s : OFF_s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigggerEnter2D(Collision2D col)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            audioSource.PlayOneShot(ONOFF_);
            Debug.Log("éÛêM");
            isOn = !isOn;
            sprite.sprite = (isOn) ? ON_s : OFF_s;
            if (!isOn) { PrtStageManagerScript.AddOffNum(); } else { PrtStageManagerScript.DecrementOffNum(); }
        }
    }

}
