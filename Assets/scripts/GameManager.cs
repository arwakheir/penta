using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] int heartCounter;
    [SerializeField] int maxHearts = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHearts(int value)
    {
        heartCounter += value;
        if (heartCounter >= maxHearts)
        {
            //move to nexger.Loat scene
            SceneManager.LoadScene("Barginfo");

        }
    }
}
