using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class1 : MonoBehaviour
{
    public void ModUpdate()
    {
        //look for a gameobject with the tag "Player" and spin it around
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.Rotate(0, 1, 0);
    }
}