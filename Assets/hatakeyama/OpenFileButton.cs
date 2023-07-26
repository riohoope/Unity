using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms; //OpenFileDialog�p�Ɏg��
using System.IO;
using UnityEngine.UI;
using EVMC4U;   //namespace�̊֐����g��
using VRM;
using VRMShaders;
using UniGLTF;
using UniHumanoid;
using SFB;
using System.Threading;
using System.Threading.Tasks;


public class OpenFileButton : MonoBehaviour
{
    public bool modelReadFlag;
    public static string filePass;
    //[SerializeField] private VRMImporterContext context;
    //public InputField fileNameField;
    GameObject teacherModel;

    void Start()
    {
        //synchronizationContext = SynchronizationContext.Current;

        modelReadFlag = false;
        teacherModel = GameObject.Find("ExternalReciever");
        this.teacherModel = GameObject.Find("ExternalReciever");

        if (Directory.Exists(UnityEngine.Application.dataPath + "\\Model") == false) //Model�t�H���_�����݂��Ȃ���Ύ����I�ɍ쐬
        {
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "\\Model");
        }
    }

    public ExternalReceiver externalReceiver;  //���I�u�W�F�N�g�̊֐����g��

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
                //ImportVRMAsync(path);
                //externalReceiver.LoadVRM(path);
                //LoadVRM(path);

            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("VRM�t�@�C����I�����Ă��������B\n", "", MessageBoxButtons.OK);
            }
        }
    }

    ////LoadVRM�����ō��

    //[SerializeField, Label("VRM���f����GameObject")]
    //public GameObject Model = null;
    //[SerializeField, Label("�ǂݍ��񂾃��f���̐eGameObject")]
    //public GameObject LoadedModelParent = null; //�ǂݍ��񂾃��f���̐e
    //[SerializeField, Label("MR���[�h�A��")]
    //public bool SyncCalibrationModeWithScaleOffsetSynchronize = true; //�L�����u���[�V�������[�h�ƃX�P�[���ݒ��A��������
    //public Action<GameObject> BeforeModelDestroyAction = null; //�j��Action
    //public Action<GameObject> AfterAutoLoadAction = null; //�������[�h��Action
    ////�����R���e�L�X�g
    //SynchronizationContext synchronizationContext;

    ////�Ǎ����͓ǂݍ��܂Ȃ�
    //bool isLoading = false;
    //public void LoadVRM(string path)
    //{
    //    DestroyModel();

    //    //�o�C�i���̓ǂݍ���
    //    if (File.Exists(path))
    //    {
    //        byte[] VRMdata = File.ReadAllBytes(path);
    //        Debug.Log("s");
    //        LoadVRMFromData(VRMdata);
    //    }
    //    else
    //    {
    //        Debug.LogError("VRM load failed.");
    //    }
    //}
    ////�t�@�C�����烂�f����ǂݍ���
    //public void LoadVRMFromData(byte[] VRMdata)
    //{
    //    if (isLoading)
    //    {
    //        Debug.LogError("Now Loading! load request is rejected.");
    //        return;
    //    }
    //    DestroyModel();

    //    //�ǂݍ���
    //    GlbLowLevelParser glbLowLevelParser = new GlbLowLevelParser(null, VRMdata);
    //    GltfData gltfData = glbLowLevelParser.Parse();
    //    VRMData vrm = new VRMData(gltfData);
    //    VRMImporterContext vrmImporter = new VRMImporterContext(vrm);

    //    isLoading = true;

    //    //�����܂ł��������Ă��Ȃ� hatakeyama

    //    synchronizationContext.Post(async (arg) => {
    //        RuntimeGltfInstance instance = await vrmImporter.LoadAsync(new VRMShaders.ImmediateCaller());
    //        isLoading = false;

    //        Model = instance.Root;

    //        //ExternalReceiver�̉��ɂԂ牺����
    //        LoadedModelParent = new GameObject();
    //        LoadedModelParent.transform.SetParent(transform, false);
    //        LoadedModelParent.name = "LoadedModelParent";
    //        //���̉��Ƀ��f�����Ԃ牺����
    //        Model.transform.SetParent(LoadedModelParent.transform, false);

    //        //instance.EnableUpdateWhenOffscreen();
    //        //instance.ShowMeshes();

    //        ////�J�����Ȃǂ̈ړ��⏕�̂��߁A���̈ʒu���i�[����
    //        //animator = Model.GetComponent<Animator>();
    //        //HeadPosition = animator.GetBoneTransform(HumanBodyBones.Head).position;

    //        ////�J��
    //        //vrmImporter.Dispose();
    //        //gltfData.Dispose();

    //        ////�ǂݍ��݌�A�N�V���������s
    //        //AfterAutoLoadAction?.Invoke(Model);
    //    }, null);
    //}

    ////���f���j��
    //public void DestroyModel()
    //{
    //    //���݂���Α��j��(�ُ��h�~)
    //    if (Model != null)
    //    {
    //        BeforeModelDestroyAction?.Invoke(Model);
    //        Destroy(Model);
    //        Model = null;
    //    }
    //    if (LoadedModelParent != null)
    //    {
    //        Destroy(LoadedModelParent);
    //        LoadedModelParent = null;
    //    }
    //}














    //private void ImportVRMAsync(string path)
    //{

    //    //�t�@�C����Byte�z��ɓǂݍ��݂܂�
    //    var bytes = File.ReadAllBytes(path);

    //    //VRMImporterContext��VRM��ǂݍ��ދ@�\��񋟂��܂�
    //    var context = new VRMImporterContext(null, null, null, null);

    //    // GLB�`����JSON���擾��Parse���܂�
    //    context.ParseGlb(bytes);

    //    // VRM�̃��^�f�[�^���擾
    //    var meta = context.ReadMeta(false); //������True�ɕς���ƃT���l�C�����ǂݍ��݂܂�

    //    //�ǂݍ��߂����ǂ������O�Ƀ��f�������o�͂��Ă݂�
    //    Debug.LogFormat("meta: title:{0}", meta.Title);

    //    //�񓯊������œǂݍ��݂܂�
    //    context.LoadAsync(_ => OnLoaded(context));
    //}

    //private void OnLoaded(VRMImporterContext context)
    //{
    //    //�Ǎ������������context.Root�Ƀ��f����GameObject�������Ă��܂�
    //    var root = context.Root;

    //    //���f�������[���h��ɔz�u���܂�
    //    root.transform.SetParent(transform, false);

    //    //���b�V����\�����܂�
    //    context.ShowMeshes();
    //}
    //public IEnumerator StreamVRMFile(string filePath)
    //{
    //    if (File.Exists(filePath))
    //    {
    //        using (WWW www = new WWW("file:///" + filePath))
    //        {
    //            UnityEngine.Cursor.lockState = CursorLockMode.Locked; // ���f���Ǎ�������ł��Ȃ��悤�ɂ���
    //            modelReadFlag = true;
    //            yield return www;

    //            byte[] VRMdata = File.ReadAllBytes(filePath);
    //            Debug.Log("s");
    //            GlbLowLevelParser glbLowLevelParser = new GlbLowLevelParser(null, VRMdata);
    //            GltfData gltfData = glbLowLevelParser.Parse();
    //            VRMData vrm = new VRMData(gltfData);
    //            VRMImporterContext VRMImporter = new VRMImporterContext(vrm);

    //            //VRMImporter.LoadVrmAsync(www.bytes, go =>
    //            VRM.VRMImporter.LoadVrmAsync(www.bytes, go =>
    //            {
    //                go.transform.position = new Vector3(-1.24f, 0f, -3.53f);
    //                go.transform.localRotation = Quaternion.Euler(0f, 10f, 0f);
    //                go.name = "VRM";
    //                ModelSetting(go, filePath);
    //            });
    //        }
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