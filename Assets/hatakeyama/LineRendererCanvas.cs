using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererCanvas : MonoBehaviour
{
	//実際に線を描画するObject
	public GameObject LineRendererObject;

	//生成した線はListで管理
	public List<GameObject> list_LineRendererObject;//録画スクリプトから呼び出すためにpublicとした

	//描画モードのON・OFF
	bool CreatLine = false;
	//描画モードのボタン
	public GameObject[] CreatLineModeButtons;
	Image[] CreatLineModeButtonColors;


	//線の設定//
	//線の幅
	private float startLineWidth = 0.01f;
	private float endLineWidth = 0.01f;
	//線の色
	private Color colorStrat = Color.red;
	private Color colorEnd = Color.red;
	private int color_s = 0;
	private int color_n = 0;

	//線の太さに関するオブジェクト
	public Text[] LineWidthText;
	//線の色に関するオブジェクト
	public Text[] LineColorText;

	// Start is called before the first frame update
	void Start()
	{

		//描画モードのボタンの色
		CreatLineModeButtonColors = new Image[CreatLineModeButtons.Length];
		for (int i = 0; i < CreatLineModeButtons.Length; i++)
		{
			CreatLineModeButtonColors[i] = CreatLineModeButtons[i].GetComponent<Image>();
		}

		//リストの初期化
		list_LineRendererObject = new List<GameObject>();

	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (CreatLine)
		{
			//左手コントローラー操作
			if (Input.GetMouseButton(0))//左クリックしたら
			{
				// カーソル位置を取得
				Vector3 mousePosition = Input.mousePosition;
				// カーソル位置のz座標を大きく
				mousePosition.z = 5;
				// カーソル位置をワールド座標に変換
				Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

				GameObject lineRendererObject = Instantiate(LineRendererObject, target, Quaternion.identity);
				list_LineRendererObject.Add(lineRendererObject);
			}
		}
	}
	//描画モードOn
	public void CreatLine_ON()
	{
		CreatLineMode("ON");
	}

	//描画モードOFF
	public void CreatLine_OFF()
	{
		CreatLineMode("OFF");
	}

	//描画モード
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

	//一つ前を削除
	public void Delete_beforeLineRenderer()
	{
		if (list_LineRendererObject.Count > 0)
		{
			Destroy(list_LineRendererObject[list_LineRendererObject.Count - 1]);
			list_LineRendererObject.RemoveAt(list_LineRendererObject.Count - 1);
		}
	}

	//すべて削除
	public void Delete_LineRenderer()
	{
		var clones = GameObject.FindGameObjectsWithTag("LineRenderer(Clone)");
		foreach (var clone in clones)
		{
			Destroy(clone);
		}
		list_LineRendererObject.Clear();
	}

	//線の太さ（最初）
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

	//線の太さ（最後）
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

	//線の色（最初）
	public void ChangeStartLineColor()
	{
		//色でループするように設定
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
				LineColorText[0].text = "赤色";
				break;
			case 1:
				colorStrat = Color.magenta;
				LineColorText[0].text = "マゼンダ";
				break;
			case 2:
				colorStrat = Color.yellow;
				LineColorText[0].text = "黄色";
				break;
			case 3:
				colorStrat = Color.green;
				LineColorText[0].text = "緑色";
				break;
			case 4:
				colorStrat = Color.cyan;
				LineColorText[0].text = "シアン";
				break;
			case 5:
				colorStrat = Color.blue;
				LineColorText[0].text = "青色";
				break;
			case 6:
				colorStrat = Color.gray;
				LineColorText[0].text = "灰色";
				break;
			case 7:
				colorStrat = Color.white;
				LineColorText[0].text = "白色";
				break;
			default:
				return;
		}
	}

	//線の色（最後）
	public void ChangeEndLineColor()
	{
		//色でループするように設定
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
				LineColorText[1].text = "赤色";
				break;
			case 1:
				colorEnd = Color.magenta;
				LineColorText[1].text = "マゼンダ";
				break;
			case 2:
				colorEnd = Color.yellow;
				LineColorText[1].text = "黄色";
				break;
			case 3:
				colorEnd = Color.green;
				LineColorText[1].text = "緑色";
				break;
			case 4:
				colorEnd = Color.cyan;
				LineColorText[1].text = "シアン";
				break;
			case 5:
				colorEnd = Color.blue;
				LineColorText[1].text = "青色";
				break;
			case 6:
				colorEnd = Color.gray;
				LineColorText[1].text = "灰色";
				break;
			case 7:
				colorEnd = Color.white;
				LineColorText[1].text = "白色";
				break;
			default:
				return;
		}
	}
}
