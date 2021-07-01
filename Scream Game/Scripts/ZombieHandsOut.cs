using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandsOut : MonoBehaviour
{
    private  GameObject dustGameObject;
    private ParticleSystem dust;
    void Start()
    {
        dustGameObject = transform.GetChild(0).gameObject;
        dust = dustGameObject.GetComponent<ParticleSystem>();
        dust.Play(false);
    }
    public void CreateDust()
    {
        dust.Play(true);
    }
}
