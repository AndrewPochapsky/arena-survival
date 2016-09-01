using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillText : MonoBehaviour {

    public Text skillText;

	// Use this for initialization
	void Start () {
        skillText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        skillText.text = Player.skillPoints.ToString();
	}
}
