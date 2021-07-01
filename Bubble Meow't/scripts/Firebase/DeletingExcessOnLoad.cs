using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingExcessOnLoad : MonoBehaviour
{
    GameObject[] FirebaseObjects;

    public string tags;
    void Start()
    {
        FirebaseObjects = GameObject.FindGameObjectsWithTag(tags);
        if(FirebaseObjects.Length>1)
        {
            for (int i = 1; i < FirebaseObjects.Length; i++)
            {
                Destroy(FirebaseObjects[i]);
            }

        }


    }
}
