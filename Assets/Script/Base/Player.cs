using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Complete {
    public class Player : MonoBehaviour {
        
        private MeshFilter _Mesh;
        private MeshRenderer _MeshRenderer;

        private void Awake() {
            _Mesh = GetComponent<MeshFilter>();
            _MeshRenderer = GetComponent<MeshRenderer>();
        }

        public void ChangeModel(Mesh setMesh, Material setMeterial) {
            _Mesh.mesh = setMesh;
            _MeshRenderer.material = setMeterial;
        }
    }

}
