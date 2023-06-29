using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms; //OpenFileDialog�p�Ɏg��
using System.IO;
using UnityEngine.UI;
using EVMC4U;
//using SFB;


public class OpenFileButton : MonoBehaviour
{
    public bool modelReadFlag;
    public static string filePass;
    //public InputField fileNameField;
    GameObject teacherModel;

    void Start()
    {
        modelReadFlag = false;
        teacherModel = GameObject.Find("ExternalReciever");
        //this.teacherModel = GameObject.Find("ExternalReciever");

        if (Directory.Exists(UnityEngine.Application.dataPath + "\\Model") == false) //Model�t�H���_�����݂��Ȃ���Ύ����I�ɍ쐬
        {
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "\\Model");
        }
    }

    public ExternalReceiver externalReceiver;

    public void ReadVRMFile()
    {
        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //�_�C�A���O���J��
        open_file_dialog.InitialDirectory = UnityEngine.Application.dataPath + "\\Model";
        open_file_dialog.Title = "�ǂݍ���VRM�t�@�C����I�����Ă�������";
        open_file_dialog.Filter = "vrm�t�@�C�� (*.vrm)|*.vrm";
        open_file_dialog.ShowDialog();

        //�擾�����t�@�C������path�ɑ������
        string path = open_file_dialog.FileName;
        if (path != "")
        {
            if (Path.GetExtension(path) == ".vrm")
            {
                //StartCoroutine(StreamVRMFile(path));
                //ImportVRMSync(path);
                externalReceiver.LoadVRM(path);
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("VRM�t�@�C����I�����Ă��������B\n", "", MessageBoxButtons.OK);
            }
        }
    }

    //public void ImportVRMSync(string path)
    //{
    //    //�t�@�C����Byte�z��ɓǂݍ��݂܂�
    //    var bytes = File.ReadAllBytes(path);

    //    //VRMImporterContext��VRM��ǂݍ��ދ@�\��񋟂��܂�
    //    var context = new VRMImporterContext();

    //    // GLB�`����JSON���擾��Parse���܂�
    //    context.ParseGlb(bytes);

    //    // VRM�̃��^�f�[�^���擾
    //    var meta = context.ReadMeta(false); //������True�ɕς���ƃT���l�C�����ǂݍ��݂܂�

    //    //�ǂݍ��߂����ǂ������O�Ƀ��f�������o�͂��Ă݂�
    //    Debug.LogFormat("meta: title:{0}", meta.Title);

    //    //���������œǂݍ��݂܂�
    //    context.Load();

    //    //�Ǎ������������context.Root�Ƀ��f����GameObject�������Ă��܂�
    //    var root = context.Root;

    //    //���f�������[���h��ɔz�u���܂�
    //    root.transform.SetParent(transform, false);
    //}

    //public IEnumerator StreamVRMFile(string filePath)
    //{
    //    if (File.Exists(filePath))
    //    {
    //        //using (WWW www = new WWW("file:///" + filePath))
    //        //{
    //        //    UnityEngine.Cursor.lockState = CursorLockMode.Locked; // ���f���Ǎ�������ł��Ȃ��悤�ɂ���
    //        //    modelReadFlag = true;
    //        //    yield return www;
    //        //VRM.VRMImporter.LoadVrmAsync(www.bytes, go =>
    //        //{
    //        //go.transform.position = new Vector3(-1.24f, 0f, -3.53f);
    //        //go.transform.localRotation = Quaternion.Euler(0f, 10f, 0f);
    //        //go.name = "VRM";
    //        //ModelSetting(go, filePath);
    //        //});
    //        //}
    //    }
    //    else // Load���̃t�@�C�������Ή�
    //    {
    //        DialogResult result;
    //        result = MessageBox.Show("vrm�t�@�C����������܂���ł����B\n", "", MessageBoxButtons.OK);
    //    }
    //}

    //void ModelSetting(GameObject model, string path)
    //{
    //    teacherModel = GameObject.Find("TeacherModel");

    //    //Destroy(teacherModel);
    //    //tl.modelPath = path;

    //    UnityEngine.Cursor.lockState = CursorLockMode.None; //���샍�b�N����
    //    UnityEngine.Cursor.visible = true;
    //}

    //�t�@�C�������擾
    //string fileName = Path.GetFileNameWithoutExtension(filePass);

    //GameManager gm = new GameManager();
    //gm.LoadModel(fileName);


    //public void ChangeModel(filePass)
    //{
    //    �C���X�^���X�����Ă���...


    //ExternalReciever�̃R���|�[�l���g�ɑ���I
    //this.model = GameObject.Find("ExternalReciever");
    //    ExternalReciever er = this.model.GetComponent<ExternalReciever>();
    //    er.Model = ;

    //}
}