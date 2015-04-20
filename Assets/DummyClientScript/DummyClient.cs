using UnityEngine;
using System.Collections;

public class DummyClient : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("!!???!!?");

		Debug.Log("キャピ👍✌️👌(これが通常のログ");
		Debug.LogWarning("イラつく絵文字も(これがWarning");
		Debug.LogError("出せる！！(これがエラー");
	}
	
	bool done;

	// Update is called once per frame
	void Update () {
		if (!done) {
			Debug.Log("とりあえずここまで");
			done = true;
		}
	}
}
