using UnityEngine;
using UnityEditor;

using System;
using System.IO;
using System.Collections.Generic;

using ARWebSocket;
using ARWebSocket.Server;

[InitializeOnLoad]
public class ServerInitializer {

	private static WebSocketServer wsServer;
	private static Action<string> emitter;

	private static List<string> offlineLogBuffer = new List<string>();

	static ServerInitializer () {
		Initialize();
	}
	
	private static void Initialize () {
		wsServer = new WebSocketServer(
			WebConsoleDefinitions.SERVE_PROTOCOL + WebConsoleDefinitions.SERVE_ADDRESS + ":" + WebConsoleDefinitions.SERVE_PORT
		);
		wsServer.AddWebSocketService<WSServerInstance>("/");
		wsServer.Start();


		// if ~ unity 4 
		// Application.RegisterLogCallback(HandleLog);

		// if unity 5 ~
		Application.logMessageReceived += HandleLog;
	}

	public static void Initialized (Action<string> emitterSource) {
		emitter = emitterSource;
	}

	public static void HandleLog (string logString, string stackTrace, LogType type) {
		if (emitter != null) {
			if (0 < offlineLogBuffer.Count) {
				foreach (var log in offlineLogBuffer) {
					EmitLogAsync(log);
				}
				
				offlineLogBuffer = new List<string>();
			}

			switch (type) {
				case LogType.Error: {
					EmitLogAsync(type + ":" + logString + "\n	" + string.Join("\n	", stackTrace.Split('\n')));
					break;
				}
				default: {
					EmitLogAsync(type + ":" + logString);
					break;
				}
			}

			
			return;
		}

		switch (type) {
			case LogType.Error: {
				offlineLogBuffer.Add(type + ":" + logString + "\n	" + string.Join("\n	", stackTrace.Split('\n')));
				break;
			}
			default: {
				offlineLogBuffer.Add(type + ":" + logString);
				break;
			}
		}
		
	}

	private static void EmitLogAsync (string message) {
		emitter(message);
	}

}