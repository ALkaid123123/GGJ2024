using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class TextBook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject book;
    public ScrollView scroll;
    List<string> tittle = new List<string>();
    List<string> content = new List<string>();
    public Text textComponent;
    string res = "";
	int Num = 0;
    void Start()
    {
        book.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            book.SetActive(true);
        }
        //发现某些线索增加信息，这里先用键盘输入代替
        if (Input.GetKeyDown(KeyCode.A))
        {
            Num++;
            tittle.Add(Num.ToString());
            content.Add("aaa");
			res = res + "/n"+"aaa";
            textComponent.text = res;
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			Num++;
			tittle.Add(Num.ToString());
			content.Add("bbb");
			res = tittle + " " + content;
			textComponent.text = "bbb";
		}

	}
}
