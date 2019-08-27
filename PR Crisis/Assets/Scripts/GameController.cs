using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GenerateInput input;
    bool held, pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            pressed = true;
        }
        else pressed = false;

        if (Input.anyKey)
        {
            held = true;
        }
        else held = false;
        for (int i = 0; i < input.sequence.Length; i++)
        {
            //input.sequence[i];
        }
        
    }
}
