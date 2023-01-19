using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAI : MonoBehaviour
{
    public float health;
    public ParticleSystem MainFire;
    public ParticleSystem Spark;
    public ParticleSystem Fire;
    public ParticleSystem Smoke;
    public ParticleSystem FireDark;
    // Start is called before the first frame update

    public FireExtinguisher.FireType fireType;
    public List<FireExtinguisher.ExtinguisherType> weaknessType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsWeakAgainst(FireExtinguisher.ExtinguisherType exType)
    {
        foreach(FireExtinguisher.ExtinguisherType eType in weaknessType)
        {
            if(eType  == exType)
            {
                return true;
            }
        }

        return false;
    }

    public void DamageFire(float damageAmount, FireExtinguisher.ExtinguisherType exType)
    {
        if(health <= 0)
        {
            return;
        }

        bool isWeak = IsWeakAgainst(exType);
        if (isWeak)
        {
            health -= damageAmount * Time.fixedDeltaTime;
            Debug.Log($"Health left: {health}");

            if (health < 80)
            {
                Fire.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            if (health < 60)
            {
                MainFire.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            if (health < 40)
            {
                Spark.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            if (health < 20)
            {
                FireDark.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            if (health <= 0)
            {
                Smoke.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                Destroy(gameObject,3);
            }
        }
        else
        {
            health += damageAmount;
            if (health >= 80)
            {
                Fire.Play(false);
            }
            if (health >= 60)
            {
                MainFire.Play(false);
            }
            if (health >= 40)
            {
                Spark.Play(false);
            }
            if (health >= 20)
            {
                FireDark.Play(false);
            }
        }

       
        
    }
}
