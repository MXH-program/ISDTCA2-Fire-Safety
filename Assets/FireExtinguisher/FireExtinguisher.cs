using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public float Ammo;
    public float SprayRate;
    bool isSpraying;
    public ParticleSystem WaterSpray;
    public enum FireType
    {
        SOLID,
        LIQUID,
        GAS,
        ELECTRICAL,
        COOKINGOIL,
        METALS
    }

    public enum ExtinguisherType
    {
        WATER,
        FOAM,
        POWDER,
        CO2,
        WETCHEMICAL
    }


    public ExtinguisherType exType;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Spray()
    {
        Debug.Log($"Spray Triggered");
        if (Ammo > 0)
        {
            isSpraying = true;
            WaterSpray.Play(false);
        }
    } 

    public void StopSpray()
    {
        Debug.Log($"Spray Stopped");
        isSpraying = false;
        WaterSpray.Stop(false, ParticleSystemStopBehavior.StopEmitting);
    }

    void OnTriggerStay(Collider other)
    {
        if (isSpraying)
        {
            // for each Fire AI, deal damage or add health if not correct weakness type
            FireAI ai = other.GetComponent<FireAI>();
            if (ai)
            {
                ai.DamageFire(SprayRate, exType);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpraying)
        {
            if (Ammo > 0)
            {
                // reduce ammo
                Ammo -= SprayRate * Time.deltaTime;
            }
            else
            {
                // stop spraying and stop the particles
                isSpraying = false;
                WaterSpray.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
        }
        else
        {
           
        }
    }
}
