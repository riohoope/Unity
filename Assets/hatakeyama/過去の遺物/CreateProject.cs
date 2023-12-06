using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProject : MonoBehaviour
{
    //Listここで作るん？意味わからん
    public List<Project> projects = new List<Project>();

    //リストに空のインスタンスを入れている
    public void Create()
    {
        //これはダメ！MonoBehaviourの中にnewはダメらしい？
        //var project = new Project
        //こっちを使う！
        //別オブジェクトの変数を使いたい時：呼びたいスクリプトにあだ名つけて，オブジェクトを探して，GetComponentでクラス名取得．インスタンス化
        Project project = GameObject.Find("DBManager").GetComponent<Project>();
        Debug.Log(project);

        projects.Add(project);
        Debug.Log(projects);
    }
}


//public var projects;

//Monobehaviourはコンストラクタ使えない．代わりにStartがある
//void Start()
//{
//    var projects = new List<Project>();
//    this.projects = projects;
//}
