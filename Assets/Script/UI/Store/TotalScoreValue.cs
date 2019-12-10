using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace complete {
	public class TotalScoreValue : MonoBehaviour {

		private void OnEnable() {
			gameObject.GetComponent<Text>().text = GameSystem.m_UIControl.GetComponent<UIControl>().GameData.TotalScore.ToString();
		}
	}
}

