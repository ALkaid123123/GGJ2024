using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
	public GameObject go;

	// Start is called before the first frame update
	void Start()
	{
		int btnPos = 10; //��һ��Button��Y��λ��
		int btnHeight = 30; //Button�ĸ߶�
		int btnCount = 100; //Button������

		GameObject panel_button = GameObject.Find("Panel_Button");
		var rectTransform = panel_button.transform.GetComponent<RectTransform>();
		panel_button.transform.localPosition = new Vector3(0, 0 - (((btnHeight * btnCount) / 2) - (rectTransform.rect.height / 2)), 0);
		rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, btnHeight * btnCount);
		go = GameObject.Find("Button");
		for (int i = 0; i < btnCount; i++)
		{
			string text = i.ToString();
			if (i == 0)
				text = "����SLAM��ʵ�ֻ�����ͬʱ��λ�ͽ�ͼ�ļ���������ǰ�˵����ۻ�������Ż����ػ���⣬����������ͽ�ͼ";

			GameObject goClone = Instantiate(go);
			goClone.transform.parent = panel_button.transform;
			goClone.transform.localScale = new Vector3(1, 1, 1);    //���ڿ�¡��Button���ű�����Ϊ0����������Ҫ����Ϊ1
			goClone.transform.localPosition = new Vector3(0, btnPos, 0);
			goClone.transform.Find("Text").GetComponent<Text>().text = text;
			goClone.transform.Find("Text").GetComponent<Text>().fontSize = 3;
			goClone.GetComponent<Button>().onClick.AddListener
			(
				() =>
				{
					Click(text);    //��Ӱ�ť����¼�
				}
			);

			//��һ��Button��λ�õ��ڵ�ǰ��ȥ���ĸ߶�
			btnPos = btnPos - btnHeight;
		}
	}

	void Click(string text)
	{
		Debug.Log(text);
	}
}
