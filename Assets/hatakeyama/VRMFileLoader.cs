using Cysharp.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;
using VRM;
using VRMShaders;
using EVMC4U;   //namespaceの関数を使う
using System.Windows.Forms; //OpenFileDialog用に使う
using System.IO;

namespace VRMTest
{
    public class VRMFileLoader : MonoBehaviour
    {
        //
        GameObject teacherModel;
        [SerializeField] private string aaa;
        private async void Start()
        {
            teacherModel = GameObject.Find("ExternalReciever");
            this.teacherModel = GameObject.Find("ExternalReciever");

            if (Directory.Exists(UnityEngine.Application.dataPath + "\\Model") == false) //Modelフォルダが存在しなければ自動的に作成
            {
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "\\Model");
            }

        }

        public ExternalReceiver externalReceiver;  //他オブジェクトの関数を使う

        public async UniTask ReadVRMFile()
        {
            //OpenFileDialog open_file_dialog = new OpenFileDialog();

            ////ダイアログを開く
            //open_file_dialog.InitialDirectory = UnityEngine.Application.dataPath + "\\Model";
            //open_file_dialog.Title = "読み込むVRMファイルを選択してください";
            //open_file_dialog.Filter = "vrmファイル (*.vrm)|*.vrm";
            //open_file_dialog.ShowDialog();

            ////取得したファイル名をpathに代入する
            //string path = open_file_dialog.FileName;
            //if (path != "")
            //{
            //    if (Path.GetExtension(path) == ".vrm")
            //    {
            //        string fileName = Path.GetFileNameWithoutExtension(path);
                    await LoadLocalVrmFile(aaa);
            //    }
            //    else
            //    {
            //        DialogResult result;
            //        result = MessageBox.Show("VRMファイルを選択してください。\n", "", MessageBoxButtons.OK);
            //    }
            //}
        }

        /// <summary>
        /// ローカルファイルの読み込み
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async UniTask LoadLocalVrmFile(string fileName)
        {
            Debug.Log(fileName);
            // 指定したPathにある.vrmのファイルをGLTF形式にパースする
            // パースもDisposeしないとメモリリークしてしまうためusingを使用
            //using var gltfData = new AutoGltfFileParser(path).Parse();
            using var gltfData = new AutoGltfFileParser($"Assets/Model/{fileName}.vrm").Parse();
            Debug.Log(gltfData);
            var vrm = new VRMData(gltfData);
            Debug.Log(vrm);
            // Disposeしないとメモリリークしてしまうためusingを使用
            using var context = new VRMImporterContext(vrm);
            Debug.Log(context);
            //非同期で読み込み
            var instance = await context.LoadAsync(new RuntimeOnlyAwaitCaller());
            //読み込み完了するとcontext.Rootに読み込んだVRMモデルのGameObjectが入っているので取得
            //var root = context.Root;
            Debug.Log("5");
            // シーン上にオブジェクト(メッシュ)表示
            instance.ShowMeshes();
        }
    }
}