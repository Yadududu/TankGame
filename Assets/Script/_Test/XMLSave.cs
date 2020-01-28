using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

namespace LMJ {
    public class XMLSave : SaveData {

        private string _FilePath;

        private void Awake() {
            _FilePath = Application.dataPath + "/byXML.txt"; //创建XML文件的存储路径
        }
        public override void Save() {
            XmlDocument xmlDoc = new XmlDocument(); //创建XML文档
            XmlElement root = xmlDoc.CreateElement("root");//创建根节点，即最上层节点
            root.SetAttribute("name", "saveFile"); //设置根节点中的值
            XmlElement score = xmlDoc.CreateElement("score");
            score.InnerText = ScoreSystem.Get.totalScore.ToString();
            root.AppendChild(score);//添加子节点

            XmlElement commodity;
            XmlElement name;
            XmlElement buyBtn;
            XmlElement selectBtn;

            foreach (BtnStore bs in btnStore) {
                commodity = xmlDoc.CreateElement("commodity");

                name = xmlDoc.CreateElement("name");
                name.InnerText = bs.name;

                buyBtn = xmlDoc.CreateElement("buyBtn");
                buyBtn.InnerText = bs.buyKeyDownSign ? "1" : "0";

                selectBtn = xmlDoc.CreateElement("selectBtn");
                selectBtn.InnerText = bs.selectKeyDownSign ? "1" : "0";

                commodity.AppendChild(name);
                commodity.AppendChild(buyBtn);
                commodity.AppendChild(selectBtn);
                root.AppendChild(commodity);
            }

            xmlDoc.AppendChild(root);
            xmlDoc.Save(_FilePath);

            if (File.Exists(Application.dataPath + "/byXML.txt")) {
                Debug.Log("保存成功");
            }
        }
        public override void Load() {
            if (File.Exists(_FilePath)) {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_FilePath);

                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("commodity");
                if (nodeList.Count != 0) {
                    for (int i = 0; i < nodeList.Count; i++) {
                        if (btnStore[i].name == nodeList[i].ChildNodes[0].InnerText) {
                            btnStore[i].Init();
                            btnStore[i].buyKeyDownSign = nodeList[i].ChildNodes[1].InnerText == "0" ? false : true;
                            if (btnStore[i].buyKeyDownSign) btnStore[i].btnBuy.onClick.Invoke();
                            btnStore[i].selectKeyDownSign = nodeList[i].ChildNodes[2].InnerText == "0" ? false : true;
                            if (btnStore[i].selectKeyDownSign) btnStore[i].btnSelect.onClick.Invoke();
                        }
                    }
                }

                XmlNodeList score = xmlDoc.GetElementsByTagName("score");
                ScoreSystem.Get.Add(int.Parse(score[0].InnerText));
                Debug.Log(ScoreSystem.Get.totalScore);
            } else {
                ScoreSystem.Get.Add(100);
                btnStore[0].Init();
                btnStore[0].btnBuy.onClick.Invoke();
                btnStore[0].btnSelect.onClick.Invoke();
                Debug.Log("存档文件不存在");
            }
        }
    }
}

