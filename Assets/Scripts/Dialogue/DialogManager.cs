using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public Text NameText;
	public Text DialogueText;
	public GameObject NextConversation;
	public GameObject StartConversation;
	public GameObject box;
	private Queue<string> sentences;
	private void Start()
	{

		sentences = new Queue<string>();
		if (StartConversation != null)
		{
			StartConversation.GetComponent<DialogTrigger>().TriggerDialogue();
		}
	}
	public void StartDialogue(Dialog dialog)
	{
		box = dialog.dialogBox;
		//dialog.dialogBox.SetActive(true);
		box.SetActive(true);
		gameObject.SetActive(true);
		if (dialog.NextConversation != null)
			NextConversation = dialog.NextConversation;
		else
			NextConversation = null;
		NameText.text = dialog.name;
		DialogueText.fontSize = dialog.fontsize;
		sentences.Clear();
		foreach (string sentence in dialog.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		DialogueText.text = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}
	IEnumerator TypeSentence(string sentence)
	{
		DialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			DialogueText.text += letter;
			yield return new WaitForSeconds(0.05f);
		}
	}
	public void EndDialogue()
	{
		//dialog.dialogBox.SetActive(false);
		gameObject.SetActive(false);
		box.SetActive(false);
		if (NextConversation != null)
		{
			NextConversation.GetComponent<DialogTrigger>().TriggerDialogue();
		}
		//DialogueText.text = "";
	}
}
