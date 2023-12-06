using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    public string school;
    public string department;
    public string region;
    public string subject;
    public string subject_goal;
    public string period_goal;
    public string evaluation_method;

    //評価で使う
    public string GetSubject()
    {
        return subject;
    }

    //新規作成したら，空のフォーマットができる
    //テキスト入力したら一番新しいやつに入れていく（のちに改え良）
}