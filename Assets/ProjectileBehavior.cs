using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    GameObject lilBuddy;

    void Start()
    {
        lilBuddy = GameObject.Find("lil buddy");
    }

    void Update()
    {
        if(Vector3.Distance(lilBuddy.transform.position, gameObject.transform.position) > 10f)
        {
            gameObject.SetActive(false);
        }
    }
}
