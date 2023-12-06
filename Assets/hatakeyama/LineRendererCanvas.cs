using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererCanvas : MonoBehaviour
{
	//���ۂɐ���`�悷��Object
	public GameObject LineRendererObject;

	//������������List�ŊǗ�
	public List<GameObject> list_LineRendererObject;//�^��X�N���v�g����Ăяo�����߂�public�Ƃ���

	//�`�惂�[�h��ON�EOFF
	bool CreatLine = false;
	//�`�惂�[�h�̃{�^��
	public GameObject[] CreatLineModeButtons;
	Image[] CreatLineModeButtonColors;


	//���̐ݒ�//
	//���̕�
	private float startLineWidth = 0.01f;
	private float endLineWidth = 0.01f;
	//���̐F
	private Color colorStrat = Color.red;
	private Color colorEnd = Color.red;
	private int color_s = 0;
	private int color_n = 0;

	//���̑����Ɋւ���I�u�W�F�N�g
	public Text[] LineWidthText;
	//���̐F�Ɋւ���I�u�W�F�N�g
	public Text[] LineColorText;

	// Start is called before the first frame update
	void Start()
	{

		//�`�惂�[�h�̃{�^���̐F
		CreatLineModeButtonColors = new Image[CreatLineModeButtons.Length];
		for (int i = 0; i < CreatLineModeButtons.Length; i++)
		{
			CreatLineModeButtonColors[i] = CreatLineModeButtons[i].GetComponent<Image>();
		}

		//���X�g�̏�����
		list_LineRendererObject = new List<GameObject>();

	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (CreatLine)
		{
			//����R���g���[���[����
			if (Input.GetMouseButton(0))//���N���b�N������
			{
				// �J�[�\���ʒu���擾
				Vector3 mousePosition = Input.mousePosition;
				// �J�[�\���ʒu��z���W��傫��
				mousePosition.z = 5;
				// �J�[�\���ʒu�����[���h���W�ɕϊ�
				Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

				GameObject lineRendererObject = Instantiate(LineRendererObject, target, Quaternion.identity);
				list_LineRendererObject.Add(lineRendererObject);
			}
		}
	}
	//�`�惂�[�hOn
	public void CreatLine_ON()
	{
		CreatLineMode("ON");
	}

	//�`�惂�[�hOFF
	public void CreatLine_OFF()
	{
		CreatLineMode("OFF");
	}

	//�`�惂�[�h
	private void CreatLineMode(string str)
	{
		if (str == "ON")
		{
			CreatLine = true;
			CreatLineModeButtonColors[0].color = Color.yellow;
			CreatLineModeButtonColors[1].color = Color.white;
		}
		else if (str == "OFF")
		{
			CreatLine = false;
			CreatLineModeButtonColors[0].color = Color.white;
			CreatLineModeButtonColors[1].color = Color.yellow;
		}
	}

	//��O���폜
	public void Delete_beforeLineRenderer()
	{
		if (list_LineRendererObject.Count > 0)
		{
			Destroy(list_LineRendererObject[list_LineRendererObject.Count - 1]);
			list_LineRendererObject.RemoveAt(list_LineRendererObject.Count - 1);
		}
	}

	//���ׂč폜
	public void Delete_LineRenderer()
	{
		var clones = GameObject.FindGameObjectsWithTag("LineRenderer(Clone)");
		foreach (var clone in clones)
		{
			Destroy(clone);
		}
		list_LineRendererObject.Clear();
	}

	//���̑����i�ŏ��j
	public void Up_ChangeStartLineWidth()
	{
		ChangeStartLineWidth("Up");
	}
	public void Down_ChangeStartLineWidth()
	{
		ChangeStartLineWidth("Down");
	}
	private void ChangeStartLineWidth(string str)
	{
		if (str == "Up")
		{
			if (startLineWidth < 0.1f)
			{
				startLineWidth += 0.005f;
			}
		}
		else if (str == "Down")
		{
			if (startLineWidth > 0.005f)
			{
				startLineWidth -= 0.005f;
			}

		}
		LineWidthText[0].text = startLineWidth.ToString();
	}

	//���̑����i�Ō�j
	public void Up_ChangeEndLineWidth()
	{
		ChangeEndLineWidth("Up");
	}
	public void Down_ChangeEndLineWidth()
	{
		ChangeEndLineWidth("Down");
	}
	private void ChangeEndLineWidth(string str)
	{
		if (str == "Up")
		{
			if (endLineWidth < 0.1f)
			{
				endLineWidth += 0.005f;
			}
		}
		else if (str == "Down")
		{
			if (endLineWidth > 0.005f)
			{
				endLineWidth -= 0.005f;
			}

		}
		LineWidthText[1].text = endLineWidth.ToString();
	}

	//���̐F�i�ŏ��j
	public void ChangeStartLineColor()
	{
		//�F�Ń��[�v����悤�ɐݒ�
		if (color_s == 7)
		{
			color_s = 0;
		}
		else
		{
			color_s++;
		}

		switch (color_s)
		{
			case 0:
				colorStrat = Color.red;
				LineColorText[0].text = "�ԐF";
				break;
			case 1:
				colorStrat = Color.magenta;
				LineColorText[0].text = "�}�[���_";
				break;
			case 2:
				colorStrat = Color.yellow;
				LineColorText[0].text = "���F";
				break;
			case 3:
				colorStrat = Color.green;
				LineColorText[0].text = "�ΐF";
				break;
			case 4:
				colorStrat = Color.cyan;
				LineColorText[0].text = "�V�A��";
				break;
			case 5:
				colorStrat = Color.blue;
				LineColorText[0].text = "�F";
				break;
			case 6:
				colorStrat = Color.gray;
				LineColorText[0].text = "�D�F";
				break;
			case 7:
				colorStrat = Color.white;
				LineColorText[0].text = "���F";
				break;
			default:
				return;
		}
	}

	//���̐F�i�Ō�j
	public void ChangeEndLineColor()
	{
		//�F�Ń��[�v����悤�ɐݒ�
		if (color_n == 7)
		{
			color_n = 0;
		}
		else
		{
			color_n++;
		}

		switch (color_n)
		{
			case 0:
				colorEnd = Color.red;
				LineColorText[1].text = "�ԐF";
				break;
			case 1:
				colorEnd = Color.magenta;
				LineColorText[1].text = "�}�[���_";
				break;
			case 2:
				colorEnd = Color.yellow;
				LineColorText[1].text = "���F";
				break;
			case 3:
				colorEnd = Color.green;
				LineColorText[1].text = "�ΐF";
				break;
			case 4:
				colorEnd = Color.cyan;
				LineColorText[1].text = "�V�A��";
				break;
			case 5:
				colorEnd = Color.blue;
				LineColorText[1].text = "�F";
				break;
			case 6:
				colorEnd = Color.gray;
				LineColorText[1].text = "�D�F";
				break;
			case 7:
				colorEnd = Color.white;
				LineColorText[1].text = "���F";
				break;
			default:
				return;
		}
	}
}
