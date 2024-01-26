using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CoinAttribute : MonoBehaviour
{
    public int CoinNumber = 0;
    public Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
		//CoinText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        if (CoinText.text != CoinNumber.ToString())
        {
            CoinText.text = CoinNumber.ToString();
        }
		if (Input.GetKeyDown(KeyCode.Q))
		{
            AddCoin();
		}
	}
    public void AddCoin()
    {
        CoinNumber++;
    }
    public void ReduceCoin()
    {
        if (CoinNumber < 0)
            CoinNumber--;
    }
}
