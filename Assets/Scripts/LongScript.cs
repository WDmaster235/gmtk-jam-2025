using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongScript : MonoBehaviour, Enemy
{

    [SerializeField] public float MaxHp { get; set; }

    [SerializeField] public float Hp { get; set; }

    [SerializeField] public float Power { get; set; }

    [SerializeField] public float Precision { get; set; }

    [SerializeField] public float dodge { get; set; }

    [SerializeField] public float deffance { get; set; }




    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(float power, float precision)
    {
        //if ((Random.Range(1, 100) - GameObject.Find("Player").GetComponent<PlayerScript>().dodge) > precision)
        //{
        //    GameObject.Find("Player").GetComponent<PlayerScript>().Hp -= power;
        //}
    }

    public void Heal(float precision)
    {
        if (Random.Range(1, 60) > precision)
        {
            Hp += 5;
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
        }
    }



    public void Spawn()
    {
        Hp = 20;

        Power = 4;

        Precision = 30;

        dodge = 2;

        deffance = 2;
    }

    public void Deffence(float precision)
    {
        if (Random.Range(1, 90) > precision)
        {
            deffance++;
            dodge++;
        }
    }

    public void Hurt(float playerPower)
    {
        if (dodge >= Random.Range(1, 30))
        {
            Hp -= (playerPower - (deffance / 20));
            dodge = 2;
            deffance = 2;

        }
    }




}