using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRespawn : MonoBehaviour
{
  [SerializeField] private Transform player;
  [SerializeField] private Transform respawnpoint;


void OnMouseDown()
{
  player.transform.position = respawnpoint.transform.position;  
}

}

