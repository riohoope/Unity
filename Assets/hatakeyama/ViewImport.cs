//using System.Collections;
//using UnityEngine;
//using SFB;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using System.Threading.Tasks;
//using UnityEngine.SceneManagement;
//using System;

//namespace UniVRM10.VRM10Viewer
//{/*=== VRM10Viewer ===*/

//    public class ViewImport : MonoBehaviour, IPointerDownHandler
//    {

//        [SerializeField]
//        public Button LoadButton;
//        public Button StartButton;
//        public Button TitleButton;
//        public GameObject AvatarPos;
//        public GameObject ReAvatar;
//        public AudioClip SE;
//        AudioSource audioSource;

//        public bool VrmLoadFlag = false;

//        void Start()
//        {

//#if !(UNITY_WEBGL && !UNITY_EDITOR)
//            LoadButton.onClick.AddListener(On_LoadFileSelect);
//#endif
//            StartButton.onClick.AddListener(OnClickGameStart);

//            if (TitleButton != null)
//            {
//                TitleButton.onClick.AddListener(OnClickGameTitle);
//            }

//            audioSource = gameObject.GetComponent<AudioSource>();

//            VrmLoadFlag = true;

//        }

//#if UNITY_WEBGL && !UNITY_EDITOR

//        //
//        // WebGL
//        //

//        // StandaloneFileBrowser�̃u���E�U�X�N���v�g�v���O�C������Ăяo��
//        [DllImport("__Internal")]
//        private static extern void UploadFile(string gameObjectName, string methodName,string   filter, bool multiple);

//        // �t�@�C�����J��
//        public void OnPointerDown(PointerEventData eventData) {
//            audioSource.PlayOneShot(SE);
//            VrmLoadFlag = false;
//            UploadFile(gameObject.name, "OnFileUpload", ".vrm", false);
//            VrmLoadFlag = true;
//        }

//        // �t�@�C���A�b�v���[�h��̏���
//        public void OnFileUpload(string url) {
//            StartCoroutine(Load(url));
//            VrmLoadFlag = true;
//        }
        
//#else
//        //
//        // OS�r���h & Unity editor��
//        //
//        public void OnPointerDown(PointerEventData eventData) { }

//        // �t�@�C�����J��
//        public void On_LoadFileSelect()
//        {

//            audioSource.PlayOneShot(SE);
//            VrmLoadFlag = false;

//            // �g���q�t�B���^
//            var extensions = new[] {
//                new ExtensionFilter("Uni-VRM v0.108.0", "vrm" ),
//            };

//            // �t�@�C���_�C�A���O���J��
//            var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
//            if (paths.Length > 0 && paths[0].Length > 0)
//            {

//                StartCoroutine(Load(new System.Uri(paths[0]).AbsoluteUri));
//                VrmLoadFlag = true;
//            }
//        }

//#endif
//        // �t�@�C���ǂݍ���
//        private IEnumerator Load(string url)
//        {

//            UnityWebRequest webRequest = UnityWebRequest.Get(url);
//            yield return webRequest.SendWebRequest();
//            if (webRequest.isNetworkError)
//            {
//                // �G���[����
//                yield break;
//            }
//            Debug.Log(webRequest.responseCode);
//            LoadVRMClicked(webRequest.downloadHandler.data);

//        }

//        public async void LoadVRMClicked(Byte[] url)
//        {

//            var path = url;

//            var instance = await LoadAsync(path, new VRMShaders.RuntimeOnlyNoThreadAwaitCaller());

//            Transform AvatarCount = AvatarPos.GetComponentInChildren<Transform>();

//            //�q�v�f��S�ď���
//            if (AvatarCount.childCount != 0)
//            {
//                //�q�I�u�W�F�N�g������擾
//                foreach (Transform child in AvatarCount.transform)
//                {
//                    //�폜����
//                    Destroy(child.gameObject);
//                }

//            }

//            //�A�o�^�[�̃Q�[���I�u�W�F�N�g���擾
//            var root = instance.gameObject;
//            //�A�o�^�[�̈ʒu���ړ�
//            root.transform.position = new Vector3(0, 0, 0);
//            root.transform.rotation = Quaternion.identity;
//            //Avatar�̎q��VRM1(�A�o�^�[�{�̂�����)
//            root.gameObject.transform.parent = AvatarPos.transform;

//        }

//        async Task<Vrm10Instance> LoadAsync(Byte[] path, VRMShaders.IAwaitCaller awaitCaller)
//        {

//            var instance = await Vrm10.LoadBytesAsync(path, awaitCaller: awaitCaller);

//            // VR�p FirstPerson �ݒ�
//            await instance.Vrm.FirstPerson.SetupAsync(instance.gameObject, awaitCaller);

//            return instance;
//        }

//        public void OnClickGameStart()
//        {
//            if (VrmLoadFlag == false)
//            {
//                return;
//            }
//            audioSource.PlayOneShot(SE);

//            ReAvatar = GameObject.Find("ReAvatar");
//            if (ReAvatar != null)
//            {
//                ReAvatar.name = "Avatar";
//            }

//            Invoke("SetBool", 1.0f);
//        }

//        public void OnClickGameTitle()
//        {
//            audioSource.PlayOneShot(SE);
//            Destroy(GameObject.Find("ReAvatar"));
//            Destroy(GameObject.Find("main"));
//            Invoke("Set_StartBool", 1.0f);
//        }

//        void SetBool()
//        {
//            SceneManager.LoadScene("MainScene");
//        }
//        void Set_StartBool()
//        {
//            SceneManager.LoadScene("StartScene");
//        }

//    }/*=== END_ViewImport ===*/

//}/*=== END_VRM10Viewer ===*/
