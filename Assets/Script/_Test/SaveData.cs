using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LMJ {
    public class SaveData : MonoBehaviour {
        public int score;
        public List<BtnStore> btnStore = new List<BtnStore>();

        public virtual void Save() {

        }
        public virtual void Load() {

        }
    }
}
