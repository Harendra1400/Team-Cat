using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonUI2 : MonoBehaviour
{
    public Text responseText;

    [System.Obsolete]
    public void SendHelloWorldMessage()
    {
        string message = "Hello World";

        StartCoroutine(SendMessageToAzureDevOpsAPI(message));
    }

    [System.Obsolete]
    private IEnumerator SendMessageToAzureDevOpsAPI(string message)
    {
        // Replace with your Azure DevOps API endpoint and Personal Access Token
        string devOpsUrl = "https://dev.azure.com/008438216/Team-Cat";
        string personalAccessToken = "cwjtp43gmlnlyc6x7db2otngmmfvubwh6xzz3i6znwtswgufy4pq";

        // Create a JSON payload with the message
        string jsonPayload = "{\"message\": \"" + message + "\"}";

        UnityWebRequest request = new UnityWebRequest(devOpsUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(":" + personalAccessToken)));

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error sending message to Azure DevOps: " + request.error);
            responseText.text = "Error: " + request.error;
        }
        else
        {
            Debug.Log("Message sent successfully to Azure DevOps");
            responseText.text = "Message sent successfully!";
        }
    }
}
