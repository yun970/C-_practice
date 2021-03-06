using System.Collections;
using System.Collections.Generic;
using UnityEngine;



struct MyVector
{
    public float x;
    public float y;
    public float z;

    public float magnitude { get { return 0; } }
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public MyVector(float x, float y, float z)
    {
        this.x  = x ; this.y  = y ; this.z  = z ;
    }

    public static MyVector operator + (MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    public static MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.x * b, a.y * b, a.z * b);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] // 리플렉션 어트리뷰트 기능
    float xpeed = 10.0f;
    PlayerController player;
    
    void Start()
    {
        //transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //GameObject go = GameObject.Find("Player");
        //player = go.GetComponent<PlayerController>();

        /*
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        MyVector dir = to - from;
        // 방향벡터
        // 1. 거리(크기)    magnitude
        // 2. 실제 방향     normalized
        dir = dir.normalized;

        MyVector mewPos = from + dir * xpeed;
        */
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;

    }
    
    void Update()
    {

    }
    void OnKeyboard()
    {
        // 회전은 =, 이동은 +=

        //yAngle += Time.deltaTime * xpeed;
        //절대 회전 값
        //transform.eulerAngles = new Vector3(0.0f, yAngle, 0.0f);

        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));
        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, yAngle, 0.0f));

        // transform.TransformDirection()  or transform.Translate()
        // Local(지역좌표) -> World(절대좌표)

        // transform.InverseTransformDirection()
        // World -> Local

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 10.1f * Time.deltaTime);
            transform.position += Vector3.forward * Time.deltaTime * xpeed;

            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * xpeed); position = 
            //Vector3.forward 는 new Vectoc3(1.0f,0.0f,0.0f,0.0f)과 같음      

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 10.0f * Time.deltaTime);
            transform.position += Vector3.back * Time.deltaTime * xpeed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 10.1f * Time.deltaTime);
            transform.position += Vector3.left * Time.deltaTime * xpeed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 10.1f * Time.deltaTime);
            transform.position += Vector3.right * Time.deltaTime * xpeed;

        }
    }
}
