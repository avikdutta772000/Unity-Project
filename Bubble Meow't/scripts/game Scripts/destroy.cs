using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float Destroy_Height=6.0f;
    void Update()
    {
        destroyOnExit();
    }
    public void destroyOnExit()
    {
        if(transform.position.y>Destroy_Height)
        {
            Destroy(this.gameObject);
        }
    }

}
