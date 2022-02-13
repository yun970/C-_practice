using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance; //static이라는 키워드의 특성상 유일성이 보장
    static Managers GetManagers() { init(); return _instance; } // 유일한 매니저클래스의 인스턴스를 호출

    InputManager _input = new InputManager();
    public static InputManager Input{ get { return GetManagers()._input; } }

    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return GetManagers()._resource; } }

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
        _input.OnUpdate(); //오브젝트에 컴포넌트로 장착되었기 때문에 managers.update()는 매 틱마다 실행되므로, 인풋매니저의 onupdate()또한 매틱마다 체크됨
    }
    static void init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" }; //유니티내의 실제 오브젝트 @Managers를 생성
                go.AddComponent<Managers>(); //오브젝트 @Managers에 스크립트인 Managers를 컴포넌트로 부착
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>(); // Managers mg 인스턴스에 컴포넌트를 연결
        }
    }
}
