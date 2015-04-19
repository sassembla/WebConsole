using UnityEngine;

using System;
using System.IO;

using ARWebSocket;
using ARWebSocket.Server;

public class WSServer : WebSocketBehavior {

	protected override void OnMessage (MessageEventArgs e) {}

	protected override void OnOpen () {
		Send("connected.");
	}

	protected override void OnClose (CloseEventArgs e) {}
}