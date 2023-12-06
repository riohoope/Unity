using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class InputText : MonoBehaviour
{

    public TMP_InputField _inputField;  //入力欄

    void Start()
    {
        _inputField = GameObject.Find("InputField (TMP) (3)").GetComponent<TMP_InputField>();
    }

    //空のインスタンスに属性を入れていきたい
    public void InputName()
    {
        string name = _inputField.text;
        Debug.Log(name);

        CreateProject createproject = GameObject.Find("DBManager").GetComponent<CreateProject>();
        createproject.projects[1].subject = name;
    }




    //public string content;  //保存したい場所
    //_inputField = GameObject.Find(_inputField).GetComponent<TMP_InputField>();
    //createproject.projects[1].content = name;

    //Debug.Log(createproject.projects[1]);
    //Debug.Log(createproject.projects[1].subject);

    //別クラスの変数を使いたい時：呼びたいスクリプトにあだ名つけて，オブジェクトを探して，GetComponentでクラス名取得





    //public GameObject obj;
    //string name = obj.GetComponent<TMP_InputField>().text;

    //public void TappedButton(string name)
    //{
    //    switch (name)
    //    {
    //        case "InputField (TMP)":
    //            Debug.Log("ボタンが押されました。");
    //            break;
    //        case "InputField (TMP) (1)":
    //            Debug.Log("ボタン(1)が押されました。");
    //            break;
    //        case "InputField (TMP) (2)":
    //            Debug.Log("ボタン(2)が押されました。");
    //            break;
    //        default:
    //            break;
    //    }
    //}



}


//[CustomEditor(typeof(InputText))]
//public class CustomButtonEditor : UnityEditor.UI.ButtonEditor
//{

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        var component = (InputText)target;

//        PropertyField(nameof(component.MyString), "My String");

//        serializedObject.ApplyModifiedProperties();
//    }

//    private void PropertyField(string property, string label)
//    {
//        EditorGUILayout.PropertyField(serializedObject.FindProperty(property), new GUIContent(label));
//    }
//}