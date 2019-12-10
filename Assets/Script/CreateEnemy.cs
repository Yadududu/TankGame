using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class CreateEnemy : MonoBehaviour {

        public ItemData ItemData;
        public GameObject EnemyPrefab;

        private GameObject LookAtPoint;
        private float CreateRate;
        private float NextCreate = 0.0F;
        private float num;
        private GameObject PrefabInstantiate;

        // Use this for initialization
        void Start() {
            CreateRate = ItemData.EnemyCreateRate;
        }

        // Update is called once per frame
        void Update() {
            
            if (Time.time > NextCreate) {

                num = Random.Range(1, 5);
                num = num * 90;
                
                NextCreate = Time.time + CreateRate;
                PrefabInstantiate = Instantiate(EnemyPrefab, gameObject.transform.position, Quaternion.Euler(0.0f, num, 0.0f), gameObject.transform);
                PrefabInstantiate.GetComponent<HeadLookAtPoint>().h_LookAtPoint = LookAtPoint;
            }
        }
        public void SetLookAtPoint(GameObject m_LookAtPoint){
            LookAtPoint = m_LookAtPoint;
        }
    }
}

