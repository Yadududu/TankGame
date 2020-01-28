using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace complete {
    public class CreateEnemy : MonoBehaviour {

        public ItemData ItemData;
        //public GameObject EnemyPrefab;

        //private GameObject LookAtPoint;
        private float _createRate;
        private float _nextCreate = 0.0F;
        private float _direction;
        private List<GameObject> _prefabPool;
        private int _uplimit = 2;

        private void Start() {
            _prefabPool = new List<GameObject>();
            _createRate = ItemData.EnemyCreateRate;
        }

        private void Update() {
            int num = 0;
            if ((Time.time > _nextCreate) & (_prefabPool.Count < _uplimit)) {

                _direction = Random.Range(1, 5);
                _direction = _direction * 90;

                _nextCreate = Time.time + _createRate;
                GameObject _prefabInstance = ObjectPoolManager.Instance.GetGameObject("EnemyPool", transform.position, Quaternion.Euler(0.0f, _direction, 0.0f), 0);
                _prefabInstance.GetComponent<EnemyHealth>().onDead.AddListener(()=>Remove(_prefabInstance));
                _prefabPool.Add(_prefabInstance);
            }
        }
        //public void SetLookAtPoint(GameObject m_LookAtPoint){
        //    LookAtPoint = m_LookAtPoint;
        //}
        private void Remove(GameObject go) {
            go.GetComponent<EnemyHealth>().onDead.RemoveAllListeners();
            _prefabPool.Remove(go);
        }
        private void RemoveAll() {
            foreach (GameObject o in _prefabPool) {
                o.GetComponent<EnemyHealth>().onDead.RemoveAllListeners();
                o.GetComponent<ObjectInfo>().RemoveGameObject();
            }
            _prefabPool.Clear();
        }
        private void OnDisable() {
            RemoveAll();
        }
    }
}

