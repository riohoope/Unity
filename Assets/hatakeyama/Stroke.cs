using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using EVMC4U;   //指先の座標取得

public class Stroke : MonoBehaviour
{

    //線の材質
    [SerializeField] Material lineMaterial;
    //線の色
    [SerializeField] Color lineColor;
    //線の太さ
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    //LineRdenerer型のリスト宣言
    List<LineRenderer> lineRenderers;

    private float _repeatSpan;    //繰り返す間隔
    private float _timeElapsed;   //経過時間

    // Start is called before the first frame update
    void Start()
    {
        //Listの初期化
        lineRenderers = new List<LineRenderer>();

        _repeatSpan = 25;    //updateの実行間隔
        _timeElapsed = 0;   //経過時間をリセット
    }

    // Update is called once per frame
    void Update()
    {
        //クリックをしたタイミング
        if (Input.GetMouseButtonDown(0))
        {
            //lineObjを生成し、初期化する
            _addLineObject();
        }

        //クリック中（ストローク中）
        if (Input.GetMouseButton(0))
        {
            _timeElapsed += 1;     //時間をカウントする

            //経過時間が繰り返す間隔を経過したら
            if (_timeElapsed >= _repeatSpan)
            {
                _addPositionDataToLineRendererList();

                _timeElapsed = 0;   //経過時間をリセットする
            }
        }

        //一つ前に戻る（Z）オブジェクトとリストのどちらも削除が必要
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(lineRenderers.Last());
            lineRenderers.RemoveAt(lineRenderers.Count - 1);
        }

        //すべて削除（D）
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var lineRender in lineRenderers)
            {
                Destroy(lineRender);
            }
            lineRenderers.Clear();
        }

    }

    //追加　クリックしたら発動
    void _addLineObject()
    {
        //空のゲームオブジェクト作成
        GameObject lineObj = new GameObject();
        //オブジェクトの名前をStrokeに変更
        lineObj.name = "Stroke";
        //lineObjにLineRendereコンポーネント追加
        lineObj.AddComponent<LineRenderer>();
        //lineRendererリストにlineObjを追加
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObjを自身の子要素に設定
        lineObj.transform.SetParent(transform);
        //lineObj初期化処理
        _initRenderers();
    }

    //lineObj初期化処理
    void _initRenderers()
    {
        //線をつなぐ点を0に初期化
        lineRenderers.Last().positionCount = 0;
        //マテリアルを初期化
        lineRenderers.Last().material = lineMaterial;
        //色の初期化
        lineRenderers.Last().material.color = lineColor;
        //太さの初期化
        lineRenderers.Last().startWidth = lineWidth / 30;
        lineRenderers.Last().endWidth = lineWidth / 30;
    }

    void _addPositionDataToLineRendererList()
    {
        //Animator取得
        //Animator animator = GetComponent<Animator>();
        //Transform target = animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
        //Debug.Log(target);
        //Vector3 target = HumanBodyBonesPositionTable[HumanBodyBones.RightIndexDistal];

        //右手人差し指の座標取得(ワールド座標)
        var indexpos = GameObject.Find("J_Bip_R_Index1").transform.position;

        //マウスポインタがあるスクリーン座標を取得
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        Vector3 mousePosition = indexpos;

        //スクリーン座標をワールド座標に変換
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //ワールド座標をローカル座標に変換
        Vector3 localPosition = transform.InverseTransformPoint(mousePosition.x, mousePosition.y, -1.0f);

        //lineRenderersの最後のlineObjのローカルポジションを上記のローカルポジションに設定
        lineRenderers.Last().transform.localPosition = localPosition;

        //lineObjの線と線をつなぐ点の数を更新
        lineRenderers.Last().positionCount += 1;

        //LineRendererコンポーネントリストを更新
        lineRenderers.Last().SetPosition(lineRenderers.Last().positionCount - 1, mousePosition);

        //あとから描いた線が上に来るように調整
        lineRenderers.Last().sortingOrder = lineRenderers.Count;
    }
}
