using Cysharp.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;
using VRM;
using VRMShaders;

namespace VRMTest
{
    public class VRMFile : MonoBehaviour
    {
        /// <summary>
        /// 読み込みたいファイル名
        /// </summary>
        [SerializeField] private string fileName;

        //private async void Start()
        //{
        //    await LoadLocalVrmFile(fileName);
        //}

        ///// <summary>
        ///// ローカルファイルの読み込み
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <returns></returns>
        //private async UniTask LoadLocalVrmFile(string fileName)
        //{
        //    // 指定したPathにある.vrmのファイルをGLTF形式にパースする
        //    // パースもDisposeしないとメモリリークしてしまうためusingを使用
        //    using var gltfData = new AutoGltfFileParser($"Assets/Model/{fileName}.vrm").Parse();
        //    var vrm = new VRMData(gltfData);

        //    // Disposeしないとメモリリークしてしまうためusingを使用
        //    using var context = new VRMImporterContext(vrm);
        //    var instance = await context.LoadAsync(new RuntimeOnlyAwaitCaller());
        //    // シーン上にオブジェクト(メッシュ)表示
        //    instance.ShowMeshes();
        //}
    }
}