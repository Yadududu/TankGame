using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete{
	public class GridDisplay : MonoBehaviour {

		public float Distance = 90;
		public string names;
		private GameObject PlaneObject;

		// Use this for initialization
		void Start () {
			// PlaneObject = GameSystem.m_GameControl.GetComponent<GameControl>().PlayerPrefabInstantiate;
		}
		private void OnEnable() {
			PlaneObject = GameSystem.m_GameControl.GetComponent<GameControl>().PlayerPrefabInstantiate;
		}
		
		// Update is called once per frame
		void Update () {
			if(PlaneObject != null){
				Debug.Log( names + Vector3.Distance(transform.position , PlaneObject.transform.position));

				if( Vector3.Distance(transform.position , PlaneObject.transform.position) <= Distance){
					gameObject.GetComponent<MeshRenderer>().enabled = true;
				}else{
					gameObject.GetComponent<MeshRenderer>().enabled = false;
				}
			}
		}
	}
}

