using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LMJ {
    public class Player : MonoBehaviour {
        
        public GameObject model;
        
        private MeshFilter _mesh;
        private MeshRenderer _meshRenderer;

        private void Awake() {
            _mesh = model.GetComponent<MeshFilter>();
            _meshRenderer = model.GetComponent<MeshRenderer>();
        }

        public void ChangeModel(Mesh setMesh, Material setMeterial) {
            _mesh.mesh = setMesh;
            _meshRenderer.material = setMeterial;
        }
    }

}
