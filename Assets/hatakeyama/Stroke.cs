using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using EVMC4U;   //�w��̍��W�擾

public class Stroke : MonoBehaviour
{

    //���̍ގ�
    [SerializeField] Material lineMaterial;
    //���̐F
    [SerializeField] Color lineColor;
    //���̑���
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    //LineRdenerer�^�̃��X�g�錾
    List<LineRenderer> lineRenderers;

    private float _repeatSpan;    //�J��Ԃ��Ԋu
    private float _timeElapsed;   //�o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        //List�̏�����
        lineRenderers = new List<LineRenderer>();

        _repeatSpan = 25;    //update�̎��s�Ԋu
        _timeElapsed = 0;   //�o�ߎ��Ԃ����Z�b�g
    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N�������^�C�~���O
        if (Input.GetMouseButtonDown(0))
        {
            //lineObj�𐶐����A����������
            _addLineObject();
        }

        //�N���b�N���i�X�g���[�N���j
        if (Input.GetMouseButton(0))
        {
            _timeElapsed += 1;     //���Ԃ��J�E���g����

            //�o�ߎ��Ԃ��J��Ԃ��Ԋu���o�߂�����
            if (_timeElapsed >= _repeatSpan)
            {
                _addPositionDataToLineRendererList();

                _timeElapsed = 0;   //�o�ߎ��Ԃ����Z�b�g����
            }
        }

        //��O�ɖ߂�iZ�j�I�u�W�F�N�g�ƃ��X�g�̂ǂ�����폜���K�v
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(lineRenderers.Last());
            lineRenderers.RemoveAt(lineRenderers.Count - 1);
        }

        //���ׂč폜�iD�j
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var lineRender in lineRenderers)
            {
                Destroy(lineRender);
            }
            lineRenderers.Clear();
        }

    }

    //�ǉ��@�N���b�N�����甭��
    void _addLineObject()
    {
        //��̃Q�[���I�u�W�F�N�g�쐬
        GameObject lineObj = new GameObject();
        //�I�u�W�F�N�g�̖��O��Stroke�ɕύX
        lineObj.name = "Stroke";
        //lineObj��LineRendere�R���|�[�l���g�ǉ�
        lineObj.AddComponent<LineRenderer>();
        //lineRenderer���X�g��lineObj��ǉ�
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj.transform.SetParent(transform);
        //lineObj����������
        _initRenderers();
    }

    //lineObj����������
    void _initRenderers()
    {
        //�����Ȃ��_��0�ɏ�����
        lineRenderers.Last().positionCount = 0;
        //�}�e���A����������
        lineRenderers.Last().material = lineMaterial;
        //�F�̏�����
        lineRenderers.Last().material.color = lineColor;
        //�����̏�����
        lineRenderers.Last().startWidth = lineWidth / 30;
        lineRenderers.Last().endWidth = lineWidth / 30;
    }

    void _addPositionDataToLineRendererList()
    {
        //Animator�擾
        //Animator animator = GetComponent<Animator>();
        //Transform target = animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
        //Debug.Log(target);
        //Vector3 target = HumanBodyBonesPositionTable[HumanBodyBones.RightIndexDistal];

        //�E��l�����w�̍��W�擾(���[���h���W)
        var indexpos = GameObject.Find("J_Bip_R_Index1").transform.position;

        //�}�E�X�|�C���^������X�N���[�����W���擾
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        Vector3 mousePosition = indexpos;

        //�X�N���[�����W�����[���h���W�ɕϊ�
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //���[���h���W�����[�J�����W�ɕϊ�
        Vector3 localPosition = transform.InverseTransformPoint(mousePosition.x, mousePosition.y, -1.0f);

        //lineRenderers�̍Ō��lineObj�̃��[�J���|�W�V��������L�̃��[�J���|�W�V�����ɐݒ�
        lineRenderers.Last().transform.localPosition = localPosition;

        //lineObj�̐��Ɛ����Ȃ��_�̐����X�V
        lineRenderers.Last().positionCount += 1;

        //LineRenderer�R���|�[�l���g���X�g���X�V
        lineRenderers.Last().SetPosition(lineRenderers.Last().positionCount - 1, mousePosition);

        //���Ƃ���`����������ɗ���悤�ɒ���
        lineRenderers.Last().sortingOrder = lineRenderers.Count;
    }
}
