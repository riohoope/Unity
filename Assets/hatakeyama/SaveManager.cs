using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    //ファイルの入出力
using System;       //Serializable
using TMPro;        //TMP系

public class SaveManager : MonoBehaviour
{

    [SerializeField] TMP_InputField inputArea_school;
    [SerializeField] TMP_InputField inputArea_department;
    [SerializeField] TMP_InputField inputArea_region;
    [SerializeField] TMP_InputField inputArea_subject;
    [SerializeField] TMP_InputField inputArea_subject_goal;
    [SerializeField] TMP_InputField inputArea_period_goal;
    [SerializeField] TMP_InputField inputArea_evaluation_method;
    [SerializeField] TMP_InputField inputArea_name;
    [SerializeField] TMP_InputField inputArea_grade;
    [SerializeField] TMP_InputField inputArea_time;
    [SerializeField] TMP_InputField inputArea_rank;
    [SerializeField] TMP_InputField inp1_1;
    [SerializeField] TMP_InputField inp1_2;
    [SerializeField] TMP_InputField inp1_3;
    [SerializeField] TMP_InputField inp2_1;
    [SerializeField] TMP_InputField inp2_2;
    [SerializeField] TMP_InputField inp2_3;
    [SerializeField] TMP_InputField inp3_1;
    [SerializeField] TMP_InputField inp3_2;
    [SerializeField] TMP_InputField inp3_3;
    [SerializeField] TMP_InputField inp4_1;
    [SerializeField] TMP_InputField inp4_2;
    [SerializeField] TMP_InputField inp4_3;
    [SerializeField] TMP_InputField inp5_1;
    [SerializeField] TMP_InputField inp5_2;
    [SerializeField] TMP_InputField inp5_3;
    [SerializeField] TMP_InputField inp6_1;
    [SerializeField] TMP_InputField inp6_2;
    [SerializeField] TMP_InputField inp6_3;
    [SerializeField] TMP_InputField inp7_1;
    [SerializeField] TMP_InputField inp7_2;
    [SerializeField] TMP_InputField inp7_3;
    [SerializeField] TMP_InputField inp8_1;
    [SerializeField] TMP_InputField inp8_2;
    [SerializeField] TMP_InputField inp8_3;
    [SerializeField] TMP_InputField inp9_1;
    [SerializeField] TMP_InputField inp9_2;
    [SerializeField] TMP_InputField inp9_3;
    [SerializeField] TMP_InputField inpmin1;
    [SerializeField] TMP_InputField inpmin2;
    [SerializeField] TMP_InputField inpmin3;
    [SerializeField] TMP_InputField inpmin4;



    [SerializeField] TextMeshProUGUI text_school;
    [SerializeField] TextMeshProUGUI text_department;
    [SerializeField] TextMeshProUGUI text_region;
    [SerializeField] TextMeshProUGUI text_subject;
    [SerializeField] TextMeshProUGUI text_subject_goal;
    [SerializeField] TextMeshProUGUI text_period_goal;
    [SerializeField] TextMeshProUGUI text_evaluation_method;
    [SerializeField] TextMeshProUGUI text_name;
    [SerializeField] TextMeshProUGUI text_grade;
    [SerializeField] TextMeshProUGUI text_time;
    [SerializeField] TextMeshProUGUI text_rank;
    [SerializeField] TextMeshProUGUI tx1_1;
    [SerializeField] TextMeshProUGUI tx1_2;
    [SerializeField] TextMeshProUGUI tx1_3;
    [SerializeField] TextMeshProUGUI tx2_1;
    [SerializeField] TextMeshProUGUI tx2_2;
    [SerializeField] TextMeshProUGUI tx2_3;
    [SerializeField] TextMeshProUGUI tx3_1;
    [SerializeField] TextMeshProUGUI tx3_2;
    [SerializeField] TextMeshProUGUI tx3_3;
    [SerializeField] TextMeshProUGUI tx4_1;
    [SerializeField] TextMeshProUGUI tx4_2;
    [SerializeField] TextMeshProUGUI tx4_3;
    [SerializeField] TextMeshProUGUI tx5_1;
    [SerializeField] TextMeshProUGUI tx5_2;
    [SerializeField] TextMeshProUGUI tx5_3;
    [SerializeField] TextMeshProUGUI tx6_1;
    [SerializeField] TextMeshProUGUI tx6_2;
    [SerializeField] TextMeshProUGUI tx6_3;
    [SerializeField] TextMeshProUGUI tx7_1;
    [SerializeField] TextMeshProUGUI tx7_2;
    [SerializeField] TextMeshProUGUI tx7_3;
    [SerializeField] TextMeshProUGUI tx8_1;
    [SerializeField] TextMeshProUGUI tx8_2;
    [SerializeField] TextMeshProUGUI tx8_3;
    [SerializeField] TextMeshProUGUI tx9_1;
    [SerializeField] TextMeshProUGUI tx9_2;
    [SerializeField] TextMeshProUGUI tx9_3;
    [SerializeField] TextMeshProUGUI txmin1;
    [SerializeField] TextMeshProUGUI txmin2;
    [SerializeField] TextMeshProUGUI txmin3;
    [SerializeField] TextMeshProUGUI txmin4;


    [Serializable]
    public class SaveData
    {

        public string school;
        public string department;
        public string region;
        public string subject;  //主キー
        public string subject_goal;
        public string period_goal;
        public string evaluation_method;
        public string name;
        public string grade;    //主キー
        public string time;
        public string rank;
        public string a1_1;
        public string a1_2;
        public string a1_3;
        public string a2_1;
        public string a2_2;
        public string a2_3;
        public string a3_1;
        public string a3_2;
        public string a3_3;
        public string a4_1;
        public string a4_2;
        public string a4_3;
        public string a5_1;
        public string a5_2;
        public string a5_3;
        public string a6_1;
        public string a6_2;
        public string a6_3;
        public string a7_1;
        public string a7_2;
        public string a7_3;
        public string a8_1;
        public string a8_2;
        public string a8_3;
        public string a9_1;
        public string a9_2;
        public string a9_3;
        public string min1;
        public string min2;
        public string min3;
        public string min4;

    }

    SaveData save = new SaveData();

    public void Save()
    {
        StreamWriter writer;
        var subject = inputArea_subject.text;
        var rank = inputArea_rank.text;
        save.subject = subject;
        save.rank = rank;

        save.school = inputArea_school.text;
        save.department = inputArea_department.text;
        save.region = inputArea_region.text;
        save.subject_goal = inputArea_subject_goal.text;
        save.period_goal = inputArea_period_goal.text;
        save.evaluation_method = inputArea_evaluation_method.text;
        save.name = inputArea_name.text;
        save.grade = inputArea_grade.text;
        save.time = inputArea_time.text;
        save.rank = inputArea_rank.text;
        save.a1_1 = inp1_1.text;
        save.a1_2 = inp1_2.text;
        save.a1_3 = inp1_3.text;
        save.a2_1 = inp2_1.text;
        save.a2_2 = inp2_2.text;
        save.a2_3 = inp2_3.text;
        save.a3_1 = inp3_1.text;
        save.a3_2 = inp3_2.text;
        save.a3_3 = inp3_3.text;
        save.a4_1 = inp4_1.text;
        save.a4_2 = inp4_2.text;
        save.a4_3 = inp4_3.text;
        save.a5_1 = inp5_1.text;
        save.a5_2 = inp5_2.text;
        save.a5_3 = inp5_3.text;
        save.a6_1 = inp6_1.text;
        save.a6_2 = inp6_2.text;
        save.a6_3 = inp6_3.text;
        save.a7_1 = inp7_1.text;
        save.a7_2 = inp7_2.text;
        save.a7_3 = inp7_3.text;
        save.a8_1 = inp8_1.text;
        save.a8_2 = inp8_2.text;
        save.a8_3 = inp8_3.text;
        save.a9_1 = inp9_1.text;
        save.a9_2 = inp9_2.text;
        save.a9_3 = inp9_3.text;
        save.min1 = inpmin1.text;
        save.min2 = inpmin2.text;
        save.min3 = inpmin3.text;
        save.min4 = inpmin4.text;

        text_school.text = inputArea_school.text;
        text_department.text = inputArea_department.text;
        text_region.text = inputArea_region.text;
        text_subject.text = inputArea_subject.text;
        text_subject_goal.text = inputArea_subject_goal.text;
        text_period_goal.text = inputArea_period_goal.text;
        text_evaluation_method.text = inputArea_evaluation_method.text;
        text_name.text = inputArea_name.text;
        text_grade.text = inputArea_grade.text;
        text_time.text = inputArea_time.text;
        text_rank.text = inputArea_rank.text;
        tx1_1.text = inp1_1.text;
        tx1_2.text = inp1_2.text;
        tx1_3.text = inp1_3.text;
        tx2_1.text = inp2_1.text;
        tx2_2.text = inp2_2.text;
        tx2_3.text = inp2_3.text;
        tx3_1.text = inp3_1.text;
        tx3_2.text = inp3_2.text;
        tx3_3.text = inp3_3.text;
        tx4_1.text = inp4_1.text;
        tx4_2.text = inp4_2.text;
        tx4_3.text = inp4_3.text;
        tx5_1.text = inp5_1.text;
        tx5_2.text = inp5_2.text;
        tx5_3.text = inp5_3.text;
        tx6_1.text = inp6_1.text;
        tx6_2.text = inp6_2.text;
        tx6_3.text = inp6_3.text;
        tx7_1.text = inp7_1.text;
        tx7_2.text = inp7_2.text;
        tx7_3.text = inp7_3.text;
        tx8_1.text = inp8_1.text;
        tx8_2.text = inp8_2.text;
        tx8_3.text = inp8_3.text;
        tx9_1.text = inp9_1.text;
        tx9_2.text = inp9_2.text;
        tx9_3.text = inp9_3.text;
        txmin1.text = inpmin1.text;
        txmin2.text = inpmin2.text;
        txmin3.text = inpmin3.text;
        txmin4.text = inpmin4.text;


        string jsonstr = JsonUtility.ToJson(save);

        writer = new StreamWriter(Application.dataPath + "/SaveData/" + subject + rank + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

        Debug.Log(jsonstr + "のデータをセーブしました");
    }

    public void Load()
    {
        string datastr = "";
        var subject = inputArea_subject.text;
        var rank = inputArea_rank.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/SaveData/" + subject + rank + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        save = JsonUtility.FromJson<SaveData>(datastr); // ロードしたデータで上書き
        Debug.Log(save.subject + save.rank + "のデータをロードしました");
        inputArea_school.text = save.school;
        inputArea_department.text = save.department;
        inputArea_region.text = save.region;
        inputArea_subject_goal.text = save.subject_goal;
        inputArea_period_goal.text = save.period_goal;
        inputArea_evaluation_method.text = save.evaluation_method;
        inputArea_name.text = save.name;
        inputArea_grade.text = save.grade;
        inputArea_time.text = save.time;
        inputArea_rank.text = save.rank;
        inp1_1.text = save.a1_1;
        inp1_2.text = save.a1_2;
        inp1_3.text = save.a1_3;
        inp2_1.text = save.a2_1;
        inp2_2.text = save.a2_2;
        inp2_3.text = save.a2_3;
        inp3_1.text = save.a3_1;
        inp3_2.text = save.a3_2;
        inp3_3.text = save.a3_3;
        inp4_1.text = save.a4_1;
        inp4_2.text = save.a4_2;
        inp4_3.text = save.a4_3;
        inp5_1.text = save.a5_1;
        inp5_2.text = save.a5_2;
        inp5_3.text = save.a5_3;
        inp6_1.text = save.a6_1;
        inp6_2.text = save.a6_2;
        inp6_3.text = save.a6_3;
        inp7_1.text = save.a7_1;
        inp7_2.text = save.a7_2;
        inp7_3.text = save.a7_3;
        inp8_1.text = save.a8_1;
        inp8_2.text = save.a8_2;
        inp8_3.text = save.a8_3;
        inp9_1.text = save.a9_1;
        inp9_2.text = save.a9_2;
        inp9_3.text = save.a9_3;
        inpmin1.text = save.min1;
        inpmin2.text = save.min2;
        inpmin3.text = save.min3;
        inpmin4.text = save.min4;


        text_school.text = save.school;//もっと増やす
    }


    public void Save2() //評価
    {
        StreamWriter writer;
        var subject = inputArea_subject.text;
        var rank = inputArea_rank.text;
        save.subject = subject;
        save.rank = rank;

        save.school = inputArea_school.text;
        save.department = inputArea_department.text;
        save.region = inputArea_region.text;
        save.subject_goal = inputArea_subject_goal.text;
        save.period_goal = inputArea_period_goal.text;
        save.evaluation_method = inputArea_evaluation_method.text;
        save.name = inputArea_name.text;
        save.grade = inputArea_grade.text;
        save.time = inputArea_time.text;
        save.rank = inputArea_rank.text;

        text_school.text = inputArea_school.text;//もっと増やす

        string jsonstr = JsonUtility.ToJson(save);

        writer = new StreamWriter(Application.dataPath + "/SaveData/" + subject + rank + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

        Debug.Log(jsonstr + "のデータをセーブしました");
    }

}


