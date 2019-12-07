using UnityEngine;
using System;
using System.Collections.Generic;
//gpg
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
//for encoding
using System.Text;
//for extra save ui
using UnityEngine.SocialPlatforms;
//for text, remove
using UnityEngine.UI;

public class GooglePlayServices
{

    public static GooglePlayServices instance;

    public static void Authentication()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (success)
            {
                Debug.Log("logged");
            }
            else
            {
                Debug.Log("Not Logged");
            }
        });
    }



    public void UnlockFirstStep()
    {
        Social.ReportProgress("CgkIzqblrPINEAIQAg", 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void SaveToCloud()
    {
        /*
        if (Authenticated)
        {
            Debug.Log("Saving progress to the cloud... filename: ");
            //save to named file
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(
                m_saveName, //name of file. If save doesn't exist it will be created with this name
                DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime,
                SavedGameOpened);
        }
        else
        {
            Debug.Log("Not authenticated!");
        }
        */
    }

    private void SavedGameLoaded(SavedGameRequestStatus status, byte[] data)
    {
        /*
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("SaveGameLoaded, success=" + status);
            ProcessCloudData(data);
        }
        else
        {
            Debug.LogWarning("Error reading game: " + status);
        }
        */
    }

}
