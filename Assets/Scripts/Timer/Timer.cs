using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private Text txtTimer;
	public float second;
	// Start is called before the first frame update
	void Start()
    {
		txtTimer = this.GetComponent<Text>();
		second = 120;
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.T))
		{
			StopAllCoroutines();
			StartCoroutine(Func());
		}
	}
	
	public void StartTimer()
	{
		if (second > 0)
		{
			second = second - 1;
			if (second / 60 < 1)
			{
				if (second < 4)
				{
					txtTimer.color = Color.red;
				}
				txtTimer.text = string.Format("00:{0:d2}", (int)second % 60);
			}
			else
			{
				txtTimer.text = string.Format("{0:d2}:{1:d2}", (int)second / 60, (int)second % 60);
			}
		}
		else
		{
			txtTimer.text = "00:00";
			txtTimer.color = Color.red;
		}
	}
	public void Reset()
	{
		second = 120;
	}
	IEnumerator Func()
	{
		while (second > 0)// or for(i;i;i)
		{
			yield return new WaitForSeconds(1.0f); // first
			StartTimer();                                  //Specific functions put here 
			Debug.Log(Time.time);   // then
									// Note the order of codes above.  Different order shows different outcome.
		}
	}
}

