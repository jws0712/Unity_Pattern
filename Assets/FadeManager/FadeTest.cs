using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour
{
    public void FadeIn()
    {
        FabeManager.instance.FadeIn(0.2f);
    }

    public void FadeOut()
    {
        FabeManager.instance.FadeOut(0.2f);
    }
}
