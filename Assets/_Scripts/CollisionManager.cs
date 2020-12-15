using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class CollisionManager : MonoBehaviour
{
    public CubeBehaviour[] actors;
    // Start is called before the first frame update
    void Start()
    {
        actors = FindObjectsOfType<CubeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < actors.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i != j)
                {
                    CheckAABBs(actors[i], actors[j]);
                }
            }
        }
    }

    public static bool Intersect(CubeBehaviour box, BulletBehaviour sphere)
    {

        var x = Math.Max(box.min.x, Math.Min(sphere.transform.position.x, box.max.x));
        var y = Math.Max(box.min.y, Math.Min(sphere.transform.position.y, box.max.y));
        var z = Math.Max(box.min.z, Math.Min(sphere.transform.position.z, box.max.z));

        var distance = Math.Sqrt((x - sphere.transform.position.x) * (x - sphere.transform.position.x) +
                                 (y - sphere.transform.position.y) * (y - sphere.transform.position.y) +
                                 (z - sphere.transform.position.z) * (z - sphere.transform.position.z));

        if (distance < sphere.transform.localScale.x && distance < sphere.transform.localScale.y && distance < sphere.transform.localScale.z)
            return true;
        else return false;
            
    }

    public static void CheckAABBs(CubeBehaviour a, CubeBehaviour b)
    {
        if ((a.min.x <= b.max.x && a.max.x >= b.min.x) &&
            (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
            (a.min.z <= b.max.z && a.max.z >= b.min.z))
        {
            if (!a.contacts.Contains(b))
            {
                a.contacts.Add(b);
                a.isColliding = true;
            }
        }
        else
        {
            if (a.contacts.Contains(b))
            {
                a.contacts.Remove(b);
                a.isColliding = false;
            }
           
        }
    }
}
