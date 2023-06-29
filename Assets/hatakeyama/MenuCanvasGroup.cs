using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI‚ðŽg‚¤‚Æ‚«’Ç‰Á

public class MenuCanvasGroup : MonoBehaviour
{
    [SerializeField] private CanvasGroup a;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (a.alpha == 1)
            {
                a.alpha = 0;
                a.blocksRaycasts = false;
            }
            else
            {
                a.alpha = 1;
                a.blocksRaycasts = true;
            }
        }
    }
}