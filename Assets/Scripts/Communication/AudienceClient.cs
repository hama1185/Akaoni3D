using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
using System.Text;
using System.Threading.Tasks;

public class AudienceClient : MonoBehaviour {
    // Start is called before the first frame update
    #region Network Settings //----------追記
    public string ip;
    public int port;
	#endregion //----------追記
    // Start is called before the first frame update

    GameObject CameraAngle;

    void Awake() {
        IpGetter ipGetter = new IpGetter();
        string myIP = ipGetter.GetIp();

        ip = HostList.ip_audience;
        if (myIP == HostList.phone1.ip) {
            port = HostList.phone1.port_audienceserver;
        }
        else {
            port = HostList.phone2.port_audienceserver;
        }
        // Debug.Log("client IP : " + ip + "   port : " + port);

        OSCHandler.Instance.clientInit("Akaoni", ip,port);//ipには接続先のipアドレスの文字列を入れる。
    }
    
    void Start() {
        CameraAngle = this.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }

    void Update() {
        List<float> transformList = new List<float>();

        transformList.Add(this.transform.position.x);
        transformList.Add(this.transform.position.y);
        transformList.Add(this.transform.position.z);

        transformList.Add(CameraAngle.transform.rotation.x);
        transformList.Add(CameraAngle.transform.rotation.y);
        transformList.Add(CameraAngle.transform.rotation.z);
        transformList.Add(CameraAngle.transform.rotation.w);

        OSCHandler.Instance.SendMessageToClient("Akaoni","/position",transformList);//Akaoniでいいのかな
    }
}