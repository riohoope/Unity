using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProject : MonoBehaviour
{
    //List�����ō���H�Ӗ��킩���
    public List<Project> projects = new List<Project>();

    //���X�g�ɋ�̃C���X�^���X�����Ă���
    public void Create()
    {
        //����̓_���IMonoBehaviour�̒���new�̓_���炵���H
        //var project = new Project
        //���������g���I
        //�ʃI�u�W�F�N�g�̕ϐ����g���������F�Ăт����X�N���v�g�ɂ��������āC�I�u�W�F�N�g��T���āCGetComponent�ŃN���X���擾�D�C���X�^���X��
        Project project = GameObject.Find("DBManager").GetComponent<Project>();
        Debug.Log(project);

        projects.Add(project);
        Debug.Log(projects);
    }
}


//public var projects;

//Monobehaviour�̓R���X�g���N�^�g���Ȃ��D�����Start������
//void Start()
//{
//    var projects = new List<Project>();
//    this.projects = projects;
//}
