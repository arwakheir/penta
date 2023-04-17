using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RemoveFragments : ExplodableAddon
{
    [SerializeField] private float fragmentsWaitTime = 2.5f;
    public override void OnFragmentsGenerated(List<GameObject> fragments)
    {
        foreach (var fragment in fragments)
        {
            Destroy(fragment,fragmentsWaitTime);
        }
    }
}
