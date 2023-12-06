using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPanel : MonoBehaviour
{
    public GameObject btn;
    public GameObject parent;

    // ボタン生成
    public void InstantiateUIBtn(GameObject parent, string name, float pos_x, float pos_y)
    {
        GameObject ui_btn = Instantiate(this.btn, new Vector3(pos_x, pos_y, 0), Quaternion.identity);

        // パネルを親に指定
        ui_btn.transform.SetParent(this.parent.transform, false);
        ui_btn.name = name;

        // クリックイベントを付与
        ui_btn.GetComponent<Button>().onClick.AddListener(() => BtnOnClick(ui_btn));
    }

    // クリックイベント内容
    void BtnOnClick(GameObject btn)
    {
        Debug.Log("ボタンをクリックしました" + btn.name);
    }
}
