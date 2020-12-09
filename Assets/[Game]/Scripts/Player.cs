using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{

    private Rigidbody rigidbody;
    public Rigidbody Rigidbody
    {
        get
        {
            if(rigidbody == null)
            {
               rigidbody = GetComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }

    public DamageEvent OnPlayerDamage = new DamageEvent();

    public float MoveSpeed;

    public int point = 0;

    private void FixedUpdate()
    {

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Rigidbody.AddForce(input * MoveSpeed * Time.deltaTime);

        Rigidbody.velocity = input * MoveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if(coin != null)
        {
            point += 1 * GameManager.Instance.LevelCoinMultiplier;
            coin.PickUpCoin(point);
        }
    }
    public int damage;
    public void DamagePlayer()
    {
        OnPlayerDamage.Invoke(damage);
    }
}
public class DamageEvent : UnityEvent<int> { }
