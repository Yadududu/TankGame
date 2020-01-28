using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
	public class HeadProtrait : MonoBehaviour {

		public GameObject[] HeadProtraits;

		public void ActionHeadProtrait(int num){
			HeadProtraits[num].SetActive(true);
		}
	}
}

