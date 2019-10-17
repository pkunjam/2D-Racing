using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Project.Utility;

public class NetworkClient : SocketIOComponent
{
    [Header("Network Client")]
    [SerializeField]
    private Transform networkContainer;

    private Dictionary<string, GameObject> serverObjects;

    public override void Start()
    {
        base.Start();
        initialize();
        setupEvents();
    }

    public override void Update()
    {
        base.Update();
    }

    private void initialize()
    {
        serverObjects = new Dictionary<string, GameObject>();
    }

    private void setupEvents()
    {
        On("open", (E) =>
        {
            Debug.Log("Connection made to the server");
        });

        On("register", (E) =>
        {
            string id = E.data[" "].ToString().RemoveQuotes();
            Debug.LogFormat("Our Client's ID ({0})", id);
        });

        On("spawn", (E) =>
        {
            //Handling all spawning players
            //Passed data
            string id = E.data["id"].ToString().RemoveQuotes();

            GameObject go = new GameObject("Server ID: " + id);
            go.transform.SetParent(networkContainer);
            serverObjects.Add(id, go);
        });

        On("disconnected", (E) =>
        {
            string id = E.data["id"].ToString().RemoveQuotes();

            GameObject go = serverObjects[id];
            Destroy(go); //Remove from game
            serverObjects.Remove(id); //Remove from memory
        });
    }
}
