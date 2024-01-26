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
		int btnPos = 10; //第一个Button的Y轴位置
		int btnHeight = 30; //Button的高度
		int btnCount = 100; //Button的数量

		GameObject panel_button = GameObject.Find("Panel_Button");
		var rectTransform = panel_button.transform.GetComponent<RectTransform>();
		panel_button.transform.localPosition = new Vector3(0, 0 - (((btnHeight * btnCount) / 2) - (rectTransform.rect.height / 2)), 0);
		rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, btnHeight * btnCount);
		go = GameObject.Find("Button");
		for (int i = 0; i < btnCount; i++)
		{
			string text = i.ToString();
			if (i == 0)
				text = "激光SLAM是实现机器人同时定位和建图的技术，包括前端点云累积，后端优化，回环检测，传感器输入和建图";

			GameObject goClone = Instantiate(go);
			goClone.transform.parent = panel_button.transform;
			goClone.transform.localScale = new Vector3(1, 1, 1);    //由于克隆的Button缩放被设置为0，所以这里要设置为1
			goClone.transform.localPosition = new Vector3(0, btnPos, 0);
			goClone.transform.Find("Text").GetComponent<Text>().text = text;
			goClone.transform.Find("Text").GetComponent<Text>().fontSize = 3;
			goClone.GetComponent<Button>().onClick.AddListener
			(
				() =>
				{
					Click(text);    //添加按钮点击事件
				}
			);

			//下一个Button的位置等于当前减去他的高度
			btnPos = btnPos - btnHeight;
		}
	}

	void Click(string text)
	{
		Debug.Log(text);
	}
}
