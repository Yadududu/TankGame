using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace complete {
    public class Test : MonoBehaviour {
       
 
        //private Transform other;//Sphere游戏对象
 
        //void Awake()
        //{
        //    //找到Sphere游戏对象
        //    other = transform.Find("/Sphere").GetComponent<Transform>();
        //}
 
        //void Start()
        //{
        //    //将Cube_1的z轴指向坐标原点（Vector.zero）到 Vector3（2，2，2）所对应的向量方向
        //   // transform.rotation = Quaternion.LookRotation(new Vector3(2, 2, 2));
        //    //将Cube_1的z轴指向原点到other.position对应向量的方向
        //    transform.rotation =  Quaternion.LookRotation(other.position);
        //}
 
        //void Update()
        //{
        //    //画线调试，画出从Cube_1到Sphere的线段
        //    Debug.DrawLine(transform.position, other.position,Color.blue);
        //    //画线调试，画出坐标原点到Sphere的射线在cube_1上的表现，即画出向量方向
        //    Debug.DrawRay(transform.position, other.position,Color.red);
        //    Move();
        //}

        //void Move() {
        //    float horizontal = Input.GetAxis("Horizontal");//获取水平偏移量（x轴）
        //    float vertical = Input.GetAxis("Vertical");    //获取垂直偏移量（z轴）
        //    //将水平偏移量与垂直偏移量组合为一个方向向量
        //    Vector3 direction = new Vector3(horizontal, 0, vertical);
        //    //判断是否有水平偏移量与垂直偏移量产生
        //    if (direction != Vector3.zero) {
        //        //将游戏对象的z轴转向对应的方向向量
        //        //            transform.rotation = Quaternion.LookRotation(direction);
        //        //对上一行代码进行插值运算则可以将转向表现得较平滑
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 0.3f);
        //        //将游戏对象进行移动变换方法则可以实现简单的物体移动
        //        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        //    }

        //}

       
            public Transform from;
            public Transform to;

            private float timeCount = 0.0f;

            //void Update() {
            //    transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
            //    timeCount = timeCount + Time.deltaTime;
            //}

            void Update() {
                Debug.Log("在Update中执行");
                Debug.Log("time:" + Time.time);
                Debug.Log("deltatime" + Time.deltaTime);
                Debug.Log("fixedtime:" + Time.fixedTime);
                Debug.Log("fixedDeltatimetime:" + Time.fixedDeltaTime);
            }
            void FixedUpdate() {
                Debug.Log("在fixedUpdate中执行");
                Debug.Log("time:" + Time.time);
                Debug.Log("deltatime" + Time.deltaTime);
                Debug.Log("fixedtime:" + Time.fixedTime);
                Debug.Log("fixedDeltatimetime:" + Time.fixedDeltaTime);
            }
        
    }

}
