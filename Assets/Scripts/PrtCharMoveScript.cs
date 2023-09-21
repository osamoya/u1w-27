using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtCharMoveScript : MonoBehaviour
{
    [SerializeField] int X;
    [SerializeField] int Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { X -= 1; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { X += 1; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Y += 1; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { Y -= 1; }

        Vector2 pos;
        pos= new Vector2(X, Y);
        transform.position = pos;
    }
}
