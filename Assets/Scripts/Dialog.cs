using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour 
{
	public DialogueNode[] node;
	public int CurrentNode;
	public bool ShowDialogue = true;
	public bool MouseClick = false;

	void OnMouseDown()
	{
		MouseClick = true;
	}

	void OnGUI() 
	{
		if (MouseClick) {
			if (ShowDialogue == true) {
				GUI.Box (new Rect (Screen.width / 8, Screen.height / 2, Screen.width * 6/8, Screen.height * 3/8), "");
				GUI.Label (new Rect (Screen.width * 3/16, Screen.height * 9/16, Screen.width * 10/16, Screen.height * 1/16), node [CurrentNode].NpcText);
				//Debug.Log ("Length = " + node [CurrentNode].PlayerAnswer.Length);
				for (int i = 0; i < node [CurrentNode].PlayerAnswer.Length; i++) {
					if (GUI.Button (new Rect (Screen.width * 3/16, Screen.height * 10/16 + 40 * i, Screen.width * 10/16, Screen.height * 1/16), node [CurrentNode].PlayerAnswer [i].Text)) {
						if (node [CurrentNode].PlayerAnswer [i].SpeekEnd) {
							ShowDialogue = false;
						}
						//Debug.Log ("Node size 1 = " + node [CurrentNode].PlayerAnswer.Length + " i 1 = " + i);
						CurrentNode = node [CurrentNode].PlayerAnswer [i].ToNode;
						//Debug.Log ("CurrentNode 2 = " + CurrentNode + " ToNode 2 = " + node [CurrentNode].PlayerAnswer [i].ToNode);
					}	
				}
			}
		}
	}
}

[System.Serializable]
public class DialogueNode
{
	public string NpcText;
	public Answer[] PlayerAnswer;
}

[System.Serializable]
public class Answer
{
	public string Text;
	public int ToNode;
	public bool SpeekEnd;
}

