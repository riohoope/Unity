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

    //�]���Ŏg��
    public string GetSubject()
    {
        return subject;
    }

    //�V�K�쐬������C��̃t�H�[�}�b�g���ł���
    //�e�L�X�g���͂������ԐV������ɓ���Ă����i�̂��ɉ����ǁj
}