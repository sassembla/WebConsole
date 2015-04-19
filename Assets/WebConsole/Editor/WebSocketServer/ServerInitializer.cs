using UnityEngine;
using UnityEditor;

using ARWebSocket;
using ARWebSocket.Server;

[InitializeOnLoad]
public class ServerInitializer {

	private static WebSocketServer wsServer;

	static ServerInitializer () {
		Init();
	}
	
	private static void Init () {
		wsServer = new WebSocketServer(WebConsoleDefinitions.SERVE_PROTOCOL + WebConsoleDefinitions.SERVE_ADDRESS + ":" + WebConsoleDefinitions.SERVE_PORT);
		wsServer.AddWebSocketService<WSServer>("/");
		wsServer.Start();
	}
}