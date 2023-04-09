using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallrespwan : MonoBehaviour
{
    [SerializeField] float lowerBoundX;
    [SerializeField] float upperBoundX;
    [SerializeField] Transform[] transformList;
    [SerializeField] bool useTransformList = false;
   // [SerializeField] GameManager gameManager;

    private Vector2 originalPosition;
    private int lastIndex;

    // Vector2 originalPosition;
     private void Start() {
        originalPosition = transform.position;
    }

  private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
          Debug.Log("hit player");
          if (useTransformList)
          {
              int index = Random.Range(0 , transformList.Length);
              if (index == lastIndex)
              {
                index++;
                if (index >= transformList.Length)
                {
                  index = 0;
                }
                lastIndex = index;
              }
              transform.position = transformList[index].position;
             //gameManager.AddWall(1);
              //check lerp
          }
          else 
          {
            float xPosition = Random.Range(lowerBoundX, upperBoundX);
            transform.position = new Vector2(xPosition, originalPosition.y);
            //gameManager.AddWall(1);
          }
    }
  }
}

// void Die()
// {
//     Respawn();
// }

// void Respawn()
// {
//     transform.position = originalPosition;
// }

    //     if (other.CompareTag("Hit"))
    //     {
    //         Die();
    //    } 