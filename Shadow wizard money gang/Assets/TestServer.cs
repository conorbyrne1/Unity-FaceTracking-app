using UnityEngine;
using Unity.LiveCapture.CompanionApp;
using Unity.LiveCapture;
public class TestServer : MonoBehaviour
{
    public CompanionAppServer newSer;
    void Start()
    {
        var servMag = ServerManager.Instance;
        newSer = (CompanionAppServer)servMag.CreateServer(typeof(CompanionAppServer));
        newSer.AutoStartOnPlay = false;
        newSer.Port = 8090;
        newSer.StartServer();
    }
    private void OnDestroy()
    {
        if (newSer)
        {
            ServerManager.Instance.DestroyServer(newSer);
            Debug.Log("Clean Server");
        }
    }
    private void OnGUI()
    {
        if (newSer)
        {
           // GUILayout.Label("PORT:" + newSer.Port.ToString());
           // GUILayout.Label("Running:" + newSer.IsRunning.ToString());
        }
        else
        {
            GUI.color = Color.red;
            GUILayout.Label("Server Not Found!");
            GUILayout.Label("PORT:--");
            GUILayout.Label("Running:--");
        }
    }
    void Update()
    {
        newSer.OnUpdate();
    }
}