using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAIHandler : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject mobiletutorialUI;
    // Start is called before the first frame update
    void Start()
    {

#if UNITY_STANDALONE //|| UNITY_WEBPLAYER
        tutorialUI.SetActive(true);
        mobiletutorialUI.SetActive(false);
#else
        tutorialUI.SetActive(false);
        mobiletutorialUI.SetActive(true);
#endif
    }
}
