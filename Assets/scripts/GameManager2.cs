using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager2 : MonoBehaviour
{
    [SerializeField] int wallbreakcounter;
    [SerializeField] int maxWall = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Addwall(int value)
    {
        wallbreakcounter += value;
        if (wallbreakcounter >= maxWall)
        {
            //move to nexger.Loat scene
            SceneManager.LoadScene("DenialInfo");

        }
    }
}
