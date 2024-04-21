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


    [SerializeField] private Image Panel; //투명도를 조절할 이미지
    private float time = 0; //페이드 인 아웃이 끝나는 시간

    /// <summary>
    /// Panel이미지의 알파값을 조절해서
    /// 페이드 인을 구현한 함수
    /// </summary>
    public void FadeIn(float FadeTime) //페이드 아웃이 끝나는 시간을 받음
    {
        StartCoroutine(FadeInFunction(FadeTime)); //받은 시간 만큼 페이드 인을 실행함
    }

    IEnumerator FadeInFunction(float FadeTime) //페이드 인 기능을 구현한 함수
    {
        Panel.gameObject.SetActive(true); //꺼져있는 패널을 켜줌
        time = 0f; //시간을 초기화 기켜줌
        Color alpha = Panel.color; //이미지의 r, g, b, a값을 가져옴
        while (alpha.a < 1f) //이미지의 알파값이 1보다 커지기 전까지 반복함
        {
            time += Time.deltaTime / FadeTime; //페이드 인이 끝나는 시간을 time에 담음
            alpha.a = Mathf.Lerp(0, 1, time); //이미지의 알파값의 0과1 사이의 값을 반복하는 동안 알파값에 담아줌(점점 진해짐)
            Panel.color = alpha; //구한 r, g, b, a값을 이미지에 적용시켜줌
            yield return null; //한 프레임 쉼
        }
    }
    /// <summary>
    /// Panel이미지의 알파값을 조절해서
    /// 페이드 아웃을 구현한 함수
    /// </summary>
    public void FadeOut(float FadeTime) //페이드 아웃이 끝나는 시간을 받음
    {
        StartCoroutine(FadeOutFunction(FadeTime)); //받은 시간만큼 페이드 아웃을 실행함
    }

    IEnumerator FadeOutFunction(float FadeTime) //페이드 아웃 기능을 구현한 함수
    {
        time = 0f; //시간을 초기화 기켜줌
        Color alpha = Panel.color; //이미지의 r, g, b, a값을 가져옴
        while (alpha.a > 0f) //이미지의 알파값이 0보다 작아지기 전까지 반복함
        {
            time += Time.deltaTime / FadeTime; //페이드 아웃이 끝나는 시간을 time에 담음
            alpha.a = Mathf.Lerp(1, 0, time); //이미지의 알파값의 1과0 사이의 값을 반복하는 동안 알파값에 담아줌(점점 투명해짐)
            Panel.color = alpha; //구한 r, g, b, a값을 이미지에 적용시켜줌
            yield return null; //한프레임 쉼
        }
        Panel.gameObject.SetActive(false); //꺼져있는 패널을 꺼줌
    }

}
