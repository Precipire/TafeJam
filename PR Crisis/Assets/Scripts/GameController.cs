using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GenerateInput input;
    bool held, pressed;
    float fill = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.anyKeyDown)
        {
            pressed = true;
        }
        else pressed = false;

        if (Input.anyKey)
        {
            held = true;
        }*/
        else held = false;
        for (int i = 0; i < input.sequence.Length; i++)
        {
            if(input.sequence[i].name.Equals("Press"))
            {
                waitForKeyPress()
                if(pressed)
                {
                    //switch sprite to "completed sprite"
                    pressed = false;
                }
            }
            
            if(input.sequence[i].name.Equals("Hold"))
            {
                if(!held)
                {
                    waitForKeyHold()
                }
                if(held)
                {
                    Hold();
                }
            }
        }
        
    }
    public IEnumerator waitForKeyHold()
    {   
        bool done = false;
        while(!done) 
        {
            if(Input.anyKey)
            {   
                done = true; 
            }
            yield return null; 
        }
        pressed = true;
    }
    
    public IEnumerator waitForKeyPress()
    {   
        bool done = false;
        while(!done) 
        {
            if(Input.anyKeyDown)
            {   
                done = true; 
            }
            yield return null; 
        }
        held = true;
    }
    
    public void Hold()
    {
        if(!Input.anyKey)
        {
            held = false;
            return;
        }
        else
        {
            if(fill<0.8f)
            {
                fill += Time.deltaTime;
            }
            else
            {
                //switch sprite to "completed sprite"
            }
        }
    }
}
