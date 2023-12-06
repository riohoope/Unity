using Cysharp.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using UnityEngine.Networking;
using VRM;
using VRMShaders;
using EVMC4U;   //namespace�̊֐����g��
using System.Windows.Forms; //OpenFileDialog�p�Ɏg��
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

            if (Directory.Exists(UnityEngine.Application.dataPath + "\\Model") == false) //Model�t�H���_�����݂��Ȃ���Ύ����I�ɍ쐬
            {
                Directory.CreateDirectory(UnityEngine.Application.dataPath + "\\Model");
            }

        }

        public ExternalReceiver externalReceiver;  //���I�u�W�F�N�g�̊֐����g��

        public async UniTask ReadVRMFile()
        {
            //OpenFileDialog open_file_dialog = new OpenFileDialog();

            ////�_�C�A���O���J��
            //open_file_dialog.InitialDirectory = UnityEngine.Application.dataPath + "\\Model";
            //open_file_dialog.Title = "�ǂݍ���VRM�t�@�C����I�����Ă�������";
            //open_file_dialog.Filter = "vrm�t�@�C�� (*.vrm)|*.vrm";
            //open_file_dialog.ShowDialog();

            ////�擾�����t�@�C������path�ɑ������
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
            //        result = MessageBox.Show("VRM�t�@�C����I�����Ă��������B\n", "", MessageBoxButtons.OK);
            //    }
            //}
        }

        /// <summary>
        /// ���[�J���t�@�C���̓ǂݍ���
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async UniTask LoadLocalVrmFile(string fileName)
        {
            Debug.Log(fileName);
            // �w�肵��Path�ɂ���.vrm�̃t�@�C����GLTF�`���Ƀp�[�X����
            // �p�[�X��Dispose���Ȃ��ƃ��������[�N���Ă��܂�����using���g�p
            //using var gltfData = new AutoGltfFileParser(path).Parse();
            using var gltfData = new AutoGltfFileParser($"Assets/Model/{fileName}.vrm").Parse();
            Debug.Log(gltfData);
            var vrm = new VRMData(gltfData);
            Debug.Log(vrm);
            // Dispose���Ȃ��ƃ��������[�N���Ă��܂�����using���g�p
            using var context = new VRMImporterContext(vrm);
            Debug.Log(context);
            //�񓯊��œǂݍ���
            var instance = await context.LoadAsync(new RuntimeOnlyAwaitCaller());
            //�ǂݍ��݊��������context.Root�ɓǂݍ���VRM���f����GameObject�������Ă���̂Ŏ擾
            //var root = context.Root;
            Debug.Log("5");
            // �V�[����ɃI�u�W�F�N�g(���b�V��)�\��
            instance.ShowMeshes();
        }
    }
}