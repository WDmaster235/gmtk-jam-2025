using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy 
{

    public float MaxHp { get; set; }

    public float Hp {  get; set; }

    public float Power { get; set; }

    public float Precision { get; set; }

    public float dodge { get; set; }

    public float deffance { get; set; }

    public void Attack(float power, float precision)
    {

    }

    public void Heal()
    {

    }

    public void Spawn() 
    {
    
    }

    public void Deffence()
    {

    }

    public void Hurt()
    {

    }



}
