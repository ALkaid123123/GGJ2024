using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialog
{
	public string name = "???";
	public GameObject dialogBox;
	//dialogBox.SetActive(false);
	public GameObject CharacterImage;
	public GameObject NextConversation;
	public GameObject ChooseBranch;
	public GameObject BackgroundImage;
	public int fontsize = 26;
	[TextArea(3,10)]
	public string[] sentences;
	
}
