using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms; //OpenFileDialog用に使う
using System.IO;
using UnityEngine.UI;
using EVMC4U;   //namespaceの関数を使う
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

        if (Directory.Exists(UnityEngine.Application.dataPath + "\\Model") == false) //Modelフォルダが存在しなければ自動的に作成
        {
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "\\Model");
        }
    }

    public ExternalReceiver externalReceiver;  //他オブジェクトの関数を使う

    public void ReadVRMFile()
    {
        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //ダイアログを開く
        open_file_dialog.InitialDirectory = UnityEngine.Application.dataPath + "\\Model";
        open_file_dialog.Title = "読み込むVRMファイルを選択してください";
        open_file_dialog.Filter = "vrmファイル (*.vrm)|*.vrm";
        open_file_dialog.ShowDialog();

        //取得したファイル名をpathに代入する
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
                result = MessageBox.Show("VRMファイルを選択してください。\n", "", MessageBoxButtons.OK);
            }
        }
    }

    ////LoadVRM自分で作る

    //[SerializeField, Label("VRMモデルのGameObject")]
    //public GameObject Model = null;
    //[SerializeField, Label("読み込んだモデルの親GameObject")]
    //public GameObject LoadedModelParent = null; //読み込んだモデルの親
    //[SerializeField, Label("MRモード連動")]
    //public bool SyncCalibrationModeWithScaleOffsetSynchronize = true; //キャリブレーションモードとスケール設定を連動させる
    //public Action<GameObject> BeforeModelDestroyAction = null; //破壊時Action
    //public Action<GameObject> AfterAutoLoadAction = null; //自動ロード時Action
    ////同期コンテキスト
    //SynchronizationContext synchronizationContext;

    ////読込中は読み込まない
    //bool isLoading = false;
    //public void LoadVRM(string path)
    //{
    //    DestroyModel();

    //    //バイナリの読み込み
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
    ////ファイルからモデルを読み込む
    //public void LoadVRMFromData(byte[] VRMdata)
    //{
    //    if (isLoading)
    //    {
    //        Debug.LogError("Now Loading! load request is rejected.");
    //        return;
    //    }
    //    DestroyModel();

    //    //読み込み
    //    GlbLowLevelParser glbLowLevelParser = new GlbLowLevelParser(null, VRMdata);
    //    GltfData gltfData = glbLowLevelParser.Parse();
    //    VRMData vrm = new VRMData(gltfData);
    //    VRMImporterContext vrmImporter = new VRMImporterContext(vrm);

    //    isLoading = true;

    //    //ここまでしか動いていない hatakeyama

    //    synchronizationContext.Post(async (arg) => {
    //        RuntimeGltfInstance instance = await vrmImporter.LoadAsync(new VRMShaders.ImmediateCaller());
    //        isLoading = false;

    //        Model = instance.Root;

    //        //ExternalReceiverの下にぶら下げる
    //        LoadedModelParent = new GameObject();
    //        LoadedModelParent.transform.SetParent(transform, false);
    //        LoadedModelParent.name = "LoadedModelParent";
    //        //その下にモデルをぶら下げる
    //        Model.transform.SetParent(LoadedModelParent.transform, false);

    //        //instance.EnableUpdateWhenOffscreen();
    //        //instance.ShowMeshes();

    //        ////カメラなどの移動補助のため、頭の位置を格納する
    //        //animator = Model.GetComponent<Animator>();
    //        //HeadPosition = animator.GetBoneTransform(HumanBodyBones.Head).position;

    //        ////開放
    //        //vrmImporter.Dispose();
    //        //gltfData.Dispose();

    //        ////読み込み後アクションを実行
    //        //AfterAutoLoadAction?.Invoke(Model);
    //    }, null);
    //}

    ////モデル破棄
    //public void DestroyModel()
    //{
    //    //存在すれば即破壊(異常顔防止)
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

    //    //ファイルをByte配列に読み込みます
    //    var bytes = File.ReadAllBytes(path);

    //    //VRMImporterContextがVRMを読み込む機能を提供します
    //    var context = new VRMImporterContext(null, null, null, null);

    //    // GLB形式でJSONを取得しParseします
    //    context.ParseGlb(bytes);

    //    // VRMのメタデータを取得
    //    var meta = context.ReadMeta(false); //引数をTrueに変えるとサムネイルも読み込みます

    //    //読み込めたかどうかログにモデル名を出力してみる
    //    Debug.LogFormat("meta: title:{0}", meta.Title);

    //    //非同期処理で読み込みます
    //    context.LoadAsync(_ => OnLoaded(context));
    //}

    //private void OnLoaded(VRMImporterContext context)
    //{
    //    //読込が完了するとcontext.RootにモデルのGameObjectが入っています
    //    var root = context.Root;

    //    //モデルをワールド上に配置します
    //    root.transform.SetParent(transform, false);

    //    //メッシュを表示します
    //    context.ShowMeshes();
    //}
    //public IEnumerator StreamVRMFile(string filePath)
    //{
    //    if (File.Exists(filePath))
    //    {
    //        using (WWW www = new WWW("file:///" + filePath))
    //        {
    //            UnityEngine.Cursor.lockState = CursorLockMode.Locked; // モデル読込中操作できないようにする
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
    //    else // Load時のファイル消失対応
    //    {
    //        DialogResult result;
    //        result = MessageBox.Show("vrmファイルが見つかりませんでした。\n", "", MessageBoxButtons.OK);
    //    }
    //}

    //void ModelSetting(GameObject model, string path)
    //{
    //    teacherModel = GameObject.Find("TeacherModel");

    //    //Destroy(teacherModel);
    //    //tl.modelPath = path;

    //    UnityEngine.Cursor.lockState = CursorLockMode.None; //操作ロック解除
    //    UnityEngine.Cursor.visible = true;
    //}

    //ファイル名を取得
    //string fileName = Path.GetFileNameWithoutExtension(filePass);

    //GameManager gm = new GameManager();
    //gm.LoadModel(fileName);


    //public void ChangeModel(filePass)
    //{
    //    インスタンス化してから...


    //ExternalRecieverのコンポーネントに代入！
    //this.model = GameObject.Find("ExternalReciever");
    //    ExternalReciever er = this.model.GetComponent<ExternalReciever>();
    //    er.Model = ;

    //}
}