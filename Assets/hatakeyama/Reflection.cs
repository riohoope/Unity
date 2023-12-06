using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPanel : MonoBehaviour
{
    public GameObject btn;
    public GameObject parent;

    // �{�^������
    public void InstantiateUIBtn(GameObject parent, string name, float pos_x, float pos_y)
    {
        GameObject ui_btn = Instantiate(this.btn, new Vector3(pos_x, pos_y, 0), Quaternion.identity);

        // �p�l����e�Ɏw��
        ui_btn.transform.SetParent(this.parent.transform, false);
        ui_btn.name = name;

        // �N���b�N�C�x���g��t�^
        ui_btn.GetComponent<Button>().onClick.AddListener(() => BtnOnClick(ui_btn));
    }

    // �N���b�N�C�x���g���e
    void BtnOnClick(GameObject btn)
    {
        Debug.Log("�{�^�����N���b�N���܂���" + btn.name);
    }
}
