using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class InputText : MonoBehaviour
{

    public TMP_InputField _inputField;  //���͗�

    void Start()
    {
        _inputField = GameObject.Find("InputField (TMP) (3)").GetComponent<TMP_InputField>();
    }

    //��̃C���X�^���X�ɑ��������Ă�������
    public void InputName()
    {
        string name = _inputField.text;
        Debug.Log(name);

        CreateProject createproject = GameObject.Find("DBManager").GetComponent<CreateProject>();
        createproject.projects[1].subject = name;
    }




    //public string content;  //�ۑ��������ꏊ
    //_inputField = GameObject.Find(_inputField).GetComponent<TMP_InputField>();
    //createproject.projects[1].content = name;

    //Debug.Log(createproject.projects[1]);
    //Debug.Log(createproject.projects[1].subject);

    //�ʃN���X�̕ϐ����g���������F�Ăт����X�N���v�g�ɂ��������āC�I�u�W�F�N�g��T���āCGetComponent�ŃN���X���擾





    //public GameObject obj;
    //string name = obj.GetComponent<TMP_InputField>().text;

    //public void TappedButton(string name)
    //{
    //    switch (name)
    //    {
    //        case "InputField (TMP)":
    //            Debug.Log("�{�^����������܂����B");
    //            break;
    //        case "InputField (TMP) (1)":
    //            Debug.Log("�{�^��(1)��������܂����B");
    //            break;
    //        case "InputField (TMP) (2)":
    //            Debug.Log("�{�^��(2)��������܂����B");
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