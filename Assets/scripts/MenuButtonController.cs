using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{

    public int index;
    [SerializeField] bool keyLeft;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis ("Horizontal") !=0){
            if(!keyLeft){
                if (Input.GetAxis ("Horizontal") < 0){
                    if(index < maxIndex){
                        index++;
                    }else
                    {
                        index = 0;
                    }
                } else if(Input.GetAxis("Horizontal") > 0){
                    if(index > 0){
                        index --;
                    }else
                    {
                        index = maxIndex;
                    }

                }
                keyLeft = true;
        }
        else
        {
            keyLeft = false;
        }
        
    }
}
}