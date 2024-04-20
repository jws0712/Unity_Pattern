using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource = null;
    [SerializeField] private AudioSource effectSource = null;
    // 무슨 기능을 개발해야하는지에 대해 미리 정의하고 개발
    // Singleton 패턴을 이용해서 구현

    // BGM을 재생하는 함수 2개
    public void PlayBGM(AudioClip clip)
    {
        // AudioClip을 받아서 bgmSource에서 재생,
        bgmSource.clip = clip;
        bgmSource.Play();
    }
    public void PlayBGM(AudioClip clip, float volume)
    {
        // AudioClip을 받아서 bgmSource에서 재생, volume을 재설정함
        //1. PlayBGM에 있는 코드들을 똑같이 복붙하여 작성, 그리고 volume에 대한 설정
        bgmSource.volume = volume;
        bgmSource.clip = clip;
        bgmSource.Play();
        //2. voluem에 대한 재설정 후 PlayBGM(AudioClip)함수를 실행
        bgmSource.volume = volume;
        PlayBGM(clip);
    }
    // Effect를 재생하는 함수 2개
    public void PlayEffect(AudioClip clip)
    {
        // AudioClip을 받아서 effectSource 재생,
        // 직접 구현
        effectSource.clip = clip;
        effectSource.Play();

        //메서드 실행
        effectSource.PlayOneShot(clip);
    }
    public void PlayEffect(AudioClip clip, float volume)
    {
        // AudioClip을 받아서 effectSource에서 재생, volume을 재설정함

        effectSource.volume = volume;
        effectSource.clip = clip;
        effectSource.Play();
        
        effectSource.PlayOneShot(clip, volume);
    }
}
