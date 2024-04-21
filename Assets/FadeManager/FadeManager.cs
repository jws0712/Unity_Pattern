using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FabeManager : MonoBehaviour
{
    public static FabeManager instance;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] private Image Panel; //������ ������ �̹���
    private float time = 0; //���̵� �� �ƿ��� ������ �ð�

    /// <summary>
    /// Panel�̹����� ���İ��� �����ؼ�
    /// ���̵� ���� ������ �Լ�
    /// </summary>
    public void FadeIn(float FadeTime) //���̵� �ƿ��� ������ �ð��� ����
    {
        StartCoroutine(FadeInFunction(FadeTime)); //���� �ð� ��ŭ ���̵� ���� ������
    }

    IEnumerator FadeInFunction(float FadeTime) //���̵� �� ����� ������ �Լ�
    {
        Panel.gameObject.SetActive(true); //�����ִ� �г��� ����
        time = 0f; //�ð��� �ʱ�ȭ ������
        Color alpha = Panel.color; //�̹����� r, g, b, a���� ������
        while (alpha.a < 1f) //�̹����� ���İ��� 1���� Ŀ���� ������ �ݺ���
        {
            time += Time.deltaTime / FadeTime; //���̵� ���� ������ �ð��� time�� ����
            alpha.a = Mathf.Lerp(0, 1, time); //�̹����� ���İ��� 0��1 ������ ���� �ݺ��ϴ� ���� ���İ��� �����(���� ������)
            Panel.color = alpha; //���� r, g, b, a���� �̹����� ���������
            yield return null; //�� ������ ��
        }
    }
    /// <summary>
    /// Panel�̹����� ���İ��� �����ؼ�
    /// ���̵� �ƿ��� ������ �Լ�
    /// </summary>
    public void FadeOut(float FadeTime) //���̵� �ƿ��� ������ �ð��� ����
    {
        StartCoroutine(FadeOutFunction(FadeTime)); //���� �ð���ŭ ���̵� �ƿ��� ������
    }

    IEnumerator FadeOutFunction(float FadeTime) //���̵� �ƿ� ����� ������ �Լ�
    {
        time = 0f; //�ð��� �ʱ�ȭ ������
        Color alpha = Panel.color; //�̹����� r, g, b, a���� ������
        while (alpha.a > 0f) //�̹����� ���İ��� 0���� �۾����� ������ �ݺ���
        {
            time += Time.deltaTime / FadeTime; //���̵� �ƿ��� ������ �ð��� time�� ����
            alpha.a = Mathf.Lerp(1, 0, time); //�̹����� ���İ��� 1��0 ������ ���� �ݺ��ϴ� ���� ���İ��� �����(���� ��������)
            Panel.color = alpha; //���� r, g, b, a���� �̹����� ���������
            yield return null; //�������� ��
        }
        Panel.gameObject.SetActive(false); //�����ִ� �г��� ����
    }

}
