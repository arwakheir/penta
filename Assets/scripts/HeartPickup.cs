using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
  [SerializeField] float lowerBoundX;
  [SerializeField] float upperBoundX;

  [SerializeField] float movementSpeed;

  [SerializeField] Transform[] transformList;
  [SerializeField] bool useTransformList = false;

  private Vector2 originalPosition;

  private void Start() {
    originalPosition = transform.position;
  }
   
  private void OnTriggerEnter2D(BoxCollider2D other) {
        if (other.tag == "Player")
        {
          if (useTransformList)
          {
              int index = Random.Range(0 , transformList.Length);
              transform.position = transformList[index].position;
              //check lerp
          }
          else 
          {
            float xPosition = Random.Range(lowerBoundX, upperBoundX);
            transform.position = new Vector2(xPosition, originalPosition.y);
          }
          
        }
    }
}
