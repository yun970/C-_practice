using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance; //static이라는 키워드의 특성상 유일성이 보장
    public static Managers GetManagers() { init(); return instance; } // 유일한 매니저클래스의 인스턴스를 호출
    // Start is called before the first frame update
    void Start()
    {
        init();
        //GameObject go = GameObject.Find("@Managers");
        //instance = go.GetComponent<Managers>();

        //instance = this
        //c# 스크립트 파일인 managers를 들고있는 @managers라는 오브젝트에게 start()가 호출되면서 자기자신에게 this를 부여
        //하지만 @managers가 여러개 있다면 유일성이 보장되지 않으므로 @Managers라는 이름과 동일한 오브젝트만 호출함으로써 유일성 부여
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static void init()
    {
        if(instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" }; //유니티내의 실제 오브젝트 @Managers를 생성
                go.AddComponent<Managers>(); //오브젝트 @Managers에 스크립트인 Managers를 컴포넌트로 부착
            }
            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>(); // Managers mg 인스턴스에 컴포넌트를 연결
        }
    }
}
