using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // �̱���
    // =============================================================
    private static Pool instance;
    public static Pool Instance { get { return instance; } }

    [SerializeField] private GameObject objectPrefab;
    // =============================================================

    // Queue(���Լ���) (���� ������ ��������)
    // Stack(���Լ���) (���߿� ������ ��������)
    [SerializeField] private Queue<Cube> cubeObjectQueue = new Queue<Cube>();

    [SerializeField] private Transform initObject;

    private void Awake()
    {
        instance = this;

        Init(10);
    }



    // 1. �ʱ�ȭ : ó���� N���� ������Ʈ���� �̸� ����
    public void Init(int count)
    {
        // Queue�� ���� ���� �� Enqueue
        // Queue���� ���� �� �� Dequeue

        for (int i = 0; i < count; i++)
        {
            cubeObjectQueue.Enqueue(CreateObject());
        }
    }

    // 1-1. ������Ʈ Instantiate
    private Cube CreateObject()
    {
        // ������Ʈ�� Instantiate
        Cube cube = GameObject.Instantiate(objectPrefab).GetComponent<Cube>();
        // ������Ʈ�� ��Ȱ��ȭ�� ���·� ����
        cube.gameObject.SetActive(false);
        // ������ ������Ʈ�� ���� �ڽ� ������Ʈ��� �����
        cube.transform.SetParent(initObject);

        return cube;
    }

    // 2. ������� �ʴ� ���� ������Ʈ ��������
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

    // 3. ����� ���� ������Ʈ�� ��ȯ�ϱ�
    public void ResetForPool(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.SetParent(initObject);
    }
}
