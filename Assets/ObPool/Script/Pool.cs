using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // 싱글톤
    // =============================================================
    private static Pool instance;
    public static Pool Instance { get { return instance; } }

    [SerializeField] private GameObject objectPrefab;
    // =============================================================

    // Queue(선입선출) (먼저 넣은게 먼저나옴)
    // Stack(후입선출) (나중에 넣은게 먼저나옴)
    [SerializeField] private Queue<Cube> cubeObjectQueue = new Queue<Cube>();

    [SerializeField] private Transform initObject;

    private void Awake()
    {
        instance = this;

        Init(10);
    }



    // 1. 초기화 : 처음에 N개의 오브젝트들을 미리 생성
    public void Init(int count)
    {
        // Queue에 값을 넣을 땐 Enqueue
        // Queue에서 값을 뺄 땐 Dequeue

        for (int i = 0; i < count; i++)
        {
            cubeObjectQueue.Enqueue(CreateObject());
        }
    }

    // 1-1. 오브젝트 Instantiate
    private Cube CreateObject()
    {
        // 오브젝트를 Instantiate
        Cube cube = GameObject.Instantiate(objectPrefab).GetComponent<Cube>();
        // 오브젝트를 비활성화된 상태로 변경
        cube.gameObject.SetActive(false);
        // 생성된 오브젝트를 나의 자식 오브젝트들로 만들기
        cube.transform.SetParent(initObject);

        return cube;
    }

    // 2. 사용하지 않는 중인 오브젝트 가져오기
    public Cube GetObject()
    {
        Cube cube;
        if (cubeObjectQueue.Count <= 0)
        {
            cube = CreateObject();
        }
        else
        {
            cube = cubeObjectQueue.Dequeue();
        }

        cube.gameObject.SetActive(true);
        cube.transform.SetParent(null);

        return cube;
    }

    // 3. 사용이 끝난 오브젝트를 반환하기
    public void ResetForPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(initObject);
    }
}
