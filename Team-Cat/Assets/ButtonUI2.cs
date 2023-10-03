using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
/*using static PlasticGui.LaunchDiffParameters;*/

public class ButtonUI2 : MonoBehaviour
{
    [Header("Azure DevOps Configuration")]
    public string personalAccessToken = "32wfcjsnq7azzghj4rdmbsxsfoidncbb2qmxbg7ntwii3ks6xvba"; // Replace with your personal access token.
    public string organizationName = "008438216"; // Replace with your Azure DevOps organization name.
    public string project = "Team-Cat"; // Replace with your Azure DevOps project name.
    private int buildDefinitionId = _build; // Replace with the ID of your build definition.

    [Header("UI Elements")]
    public Button buildButton;
    public Text statusText;

    private const string DevOpsApiUrl = "https://dev.azure.com/008438216/";
    private static readonly int _build;

    void Start()
    {
        buildButton.onClick.AddListener(Update);
    }

    // Update is called once per frame
    async void Update()
    {
        statusText.text = "Triggering build...";

        try
        {
            string requestUrl = string.Format(DevOpsApiUrl, organizationName, project);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken))));

                var requestBody = new
                {
                    definition = new { id = buildDefinitionId }
                };

                var content = new StringContent(JsonUtility.ToJson(requestBody), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    statusText.text = "Build triggered successfully!";
                }
                else
                {
                    statusText.text = "Failed to trigger build. Check your Azure DevOps configuration.";
                }
            }
        }
        catch (Exception ex)
        {
            statusText.text = "An error occurred: " + ex.Message;
        }
    }
}

