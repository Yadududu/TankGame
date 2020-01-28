using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;


namespace LMJ {
    public class ReadXmlData : MonoBehaviour {

        public GameObject perfab;
        public Transform parent;
        public SaveData saveData;

        private GameObject _InstancePerfab;
        private Image _Image;
        private Text _Text;
        private List<Data> _DataList = new List<Data>();
        private BtnStore _BtnStore;

        void Start() {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Assets\\Script\\_Test\\TankData.xml");
            XmlNode rootNode = xmlDoc.FirstChild;
            XmlNodeList nodeList = rootNode.ChildNodes;
            foreach (XmlNode partialNode in nodeList) {
                XmlNodeList dataNodeList = partialNode.ChildNodes;
                foreach (XmlNode dataNode in dataNodeList) {
                    Data data = new Data();
                    XmlAttributeCollection col = dataNode.Attributes;
                    data.name = col["name"].Value;
                    data.price = col["price"].Value;
                    data.bullet = col["bullet"].Value;
                    data.image = col["image"].Value;
                    data.mesh = col["model"].Value;
                    data.material = col["material"].Value;
                    _DataList.Add(data);
                }
            }
            //foreach (Data data in _dataList) {
            //    Debug.Log(data.ToString());
            //}
            for (int i = 0; i < _DataList.Count; i++) {
                _InstancePerfab = Instantiate(perfab, parent);
                _Image = _InstancePerfab.transform.Find("Image").GetComponent<Image>();
                _Image.sprite = Resources.Load(_DataList[i].image, typeof(Sprite)) as Sprite;
                _Text = _InstancePerfab.transform.Find("TxtPrice").GetComponent<Text>();
                _Text.text = _DataList[i].price;
                _BtnStore = _InstancePerfab.GetComponent<BtnStore>();
                _BtnStore.mesh = Resources.Load(_DataList[i].mesh, typeof(Mesh)) as Mesh;
                _BtnStore.material = Resources.Load(_DataList[i].material, typeof(Material)) as Material;
                _BtnStore.doubleBullet = _DataList[i].bullet == "2" ? true : false;
                _BtnStore.modeName = _DataList[i].name;
                saveData.btnStore.Add(_BtnStore);
            }

            saveData.Load();

        }
    }
    public class Data {
        public string name;
        public string price;
        public string bullet;
        public string image;
        public string mesh;
        public string material;

        public override string ToString() {
            return "name:" + name + ",price:" + price + ",image:" + image;
        }
    }
}
    