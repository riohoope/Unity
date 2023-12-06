using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//追加
using UnityEngine.SceneManagement;//シーン切り替えに必要

public class ChangeScene : MonoBehaviour
{
/*  
    public Button SceneEx;
    public Button SceneB;
    public Button SceneC;
*/

    public void MoveProduct()
    {
        SceneManager.LoadScene("ExternalReceiver");
    }

}