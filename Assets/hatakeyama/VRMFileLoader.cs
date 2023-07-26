using Cysharp.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;
using VRM;
using VRMShaders;

namespace VRMTest
{
    public class VRMFileLoader : MonoBehaviour
    {
        /// <summary>
        /// ���[�J���̂��̂����ɍs�����ǂ���
        /// </summary>
        [SerializeField] private bool isLoal;

        /// <summary>
        /// �ǂݍ��݂����t�@�C����
        /// </summary>
        [SerializeField] private string fileName;

        private async void Start()
        {
            if (isLoal) await LoadLocalVrmFile(fileName);
        }

        /// <summary>
        /// ���[�J���t�@�C���̓ǂݍ���
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async UniTask LoadLocalVrmFile(string fileName)
        {
            // �w�肵��Path�ɂ���.vrm�̃t�@�C����GLTF�`���Ƀp�[�X����
            // �p�[�X��Dispose���Ȃ��ƃ��������[�N���Ă��܂�����using���g�p
            using var gltfData = new AutoGltfFileParser($"Assets/Model/{fileName}.vrm").Parse();
            var vrm = new VRMData(gltfData);

            // Dispose���Ȃ��ƃ��������[�N���Ă��܂�����using���g�p
            using var context = new VRMImporterContext(vrm);
            var instance = await context.LoadAsync(new RuntimeOnlyAwaitCaller());
            // �V�[����ɃI�u�W�F�N�g(���b�V��)�\��
            instance.ShowMeshes();
        }
    }
}