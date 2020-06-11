using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
public class PanelController : MonoBehaviour{

    public Button localImgBtn;
    public Button netWorkImgBtn;
    public Button jsonBtn;
    public Button xmlBtn;

    public Image image;
    public Text text;

    private string localImgSrc;
    private string netWorkImgSrc;
    private string xmlSrc;
    private string jsonSrc;
    void Awake()
    {
        localImgSrc = "file://" + Application.streamingAssetsPath + "/title.png";
        netWorkImgSrc = "http://netresbig.joymeng.com/readapp/grade/1a/title.png";
        xmlSrc = "file://" + Application.streamingAssetsPath + "/Task.xml";
        jsonSrc = "file://" + Application.streamingAssetsPath + "/test.json";


        localImgBtn.onClick.AddListener(Onclick_LocalImg);
        netWorkImgBtn.onClick.AddListener(Onclick_NetWorkImg);
        jsonBtn.onClick.AddListener(Onclick_Json);
        xmlBtn.onClick.AddListener(Onclick_XML);
    }


    private void Onclick_LocalImg()
    {
        Loader.Instance.loadTexture += LoadImage;
        Loader.Instance.LoadTexture(localImgSrc);
    }
    private void Onclick_NetWorkImg()
    {
        Loader.Instance.loadTexture += LoadImage;
        Loader.Instance.LoadTexture(netWorkImgSrc);
    }
    private void Onclick_Json()
    {
        Loader.Instance.loadText += LoadJson;
        Loader.Instance.LoadText(jsonSrc);
    }

    private void Onclick_XML()
    {
        Loader.Instance.loadText += LoadXml;
        Loader.Instance.LoadText(xmlSrc);
    }


    private void LoadImage(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }

    private void LoadJson(string json)
    {
        JsonData jsonData=JsonUtility.FromJson<JsonData>(json);
        text.text = jsonData.gameName;
 /*       Debug.Log(jsonData.gameName);
        Debug.Log(jsonData.version);
        Debug.Log(jsonData.isStereo);
        Debug.Log(jsonData.isUseHardWare);
        Debug.Log(jsonData.statusList[0].id);
        Debug.Log(jsonData.statusList[0].name);*/
    }




    private void LoadXml(string str)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(str);
        XmlElement root = xmldoc.DocumentElement;
        text.text = "";
        read(root);
    }

    private void read(XmlElement root)
    {
        XmlNodeList nodeList = root.ChildNodes;
        foreach (XmlElement xe in nodeList)
        {
            text.text += string.Format("{0},{1},{2}", xe.Name, xe.GetAttribute("name"), xe.GetAttribute("value")) + "\r\n";
            if (xe.ChildNodes.Count > 0)
            {
                read(xe);
            }
        }
    }


    /// <summary>
    /// 松开按钮，移除委托
    /// </summary>
    public void ReleaseBtn()
    {
        Loader.Instance.loadTexture -= LoadImage;
        Loader.Instance.loadText -= LoadXml;
        Loader.Instance.loadText -= LoadJson;
    }



    [System.Serializable]
    public class JsonData
    {
        public string gameName;
        public float version;
        public bool isStereo;
        public string isUseHardWare;
        public StatusListItem[] statusList;
    }
    [System.Serializable]
    public class StatusListItem
    {
        public string name;
        public string id;
    }
}
