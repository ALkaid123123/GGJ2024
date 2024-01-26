using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialog Dialog;
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogManager>().StartDialogue(Dialog);
	}
}
