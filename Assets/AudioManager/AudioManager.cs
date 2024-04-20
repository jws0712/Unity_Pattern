using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource = null;
    [SerializeField] private AudioSource effectSource = null;
    // ���� ����� �����ؾ��ϴ����� ���� �̸� �����ϰ� ����
    // Singleton ������ �̿��ؼ� ����

    // BGM�� ����ϴ� �Լ� 2��
    public void PlayBGM(AudioClip clip)
    {
        // AudioClip�� �޾Ƽ� bgmSource���� ���,
        bgmSource.clip = clip;
        bgmSource.Play();
    }
    public void PlayBGM(AudioClip clip, float volume)
    {
        // AudioClip�� �޾Ƽ� bgmSource���� ���, volume�� �缳����
        //1. PlayBGM�� �ִ� �ڵ���� �Ȱ��� �����Ͽ� �ۼ�, �׸��� volume�� ���� ����
        bgmSource.volume = volume;
        bgmSource.clip = clip;
        bgmSource.Play();
        //2. voluem�� ���� �缳�� �� PlayBGM(AudioClip)�Լ��� ����
        bgmSource.volume = volume;
        PlayBGM(clip);
    }
    // Effect�� ����ϴ� �Լ� 2��
    public void PlayEffect(AudioClip clip)
    {
        // AudioClip�� �޾Ƽ� effectSource ���,
        // ���� ����
        effectSource.clip = clip;
        effectSource.Play();

        //�޼��� ����
        effectSource.PlayOneShot(clip);
    }
    public void PlayEffect(AudioClip clip, float volume)
    {
        // AudioClip�� �޾Ƽ� effectSource���� ���, volume�� �缳����

        effectSource.volume = volume;
        effectSource.clip = clip;
        effectSource.Play();
        
        effectSource.PlayOneShot(clip, volume);
    }
}
