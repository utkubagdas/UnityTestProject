using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{

    private void Awake()
    {
        CoinManager.Instance.AddCoin(this);
    }

 


    public void PickUpCoin(int point)
    {
        EventManager.OnCoinPickUp.Invoke();
        CoinManager.Instance.RemoveCoin(this);
        Destroy(gameObject);
    }
}
