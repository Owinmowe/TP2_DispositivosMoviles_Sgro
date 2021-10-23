using UnityEngine;
public class PlugInImpl
{
    const string PACK_NAME = "com.example.logger";
    const string LOGGER_CLASS_NAME = "Logger";

    static AndroidJavaClass LoggerClass = null;
    static AndroidJavaObject LoggerInstance = null;

    static void Init() 
    {
        LoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        LoggerInstance = LoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
    }

    public static void SendLog(string msg) 
    {
        if (LoggerInstance == null) Init();
        LoggerInstance.Call("SendLog", msg);
    }

}
