﻿using UnityEngine;
using System.Collections;

public class Vendor : Interactable
{
    [Space(10)]
    [Range(0, 99)]
    public  int         itemCount;
    public  GameObject  vendorItem;
    public  Transform   dispensingPoint;

    public override void Interact(GameObject go)
    {
        if (itemCount <= 0)
            return;

        SceneManager sm = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        GameObject dropped = Instantiate(vendorItem) as GameObject;
        Rigidbody rb = dropped.GetComponent<Rigidbody>();

        dropped.transform.SetParent(sm.propContainer);
        dropped.transform.position = dispensingPoint.position;
        dropped.transform.rotation = UnityEngine.Random.rotation;

        Vector3 velocity = -transform.up;
        rb.velocity = velocity;

        Vector3 angular = UnityEngine.Random.insideUnitSphere;
        rb.angularVelocity = angular;

        itemCount--;
    }
}
