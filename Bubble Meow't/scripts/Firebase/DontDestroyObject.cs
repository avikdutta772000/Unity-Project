using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
   void StayAwake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
