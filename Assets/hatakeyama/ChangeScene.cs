using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�ǉ�
using UnityEngine.SceneManagement;//�V�[���؂�ւ��ɕK�v

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