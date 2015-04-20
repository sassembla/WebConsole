using UnityEngine;

using System;

using ARWebSocket;
using ARWebSocket.Server;

/**
	Send log message to browser.
*/
public class WSServerInstance : WebSocketBehavior {

	protected override void OnMessage (MessageEventArgs e) {}

	protected override void OnOpen () {
		Send("Log:---------- connected to Unity:" + DateTime.Now + " ----------");

		ServerInitializer.Initialized(this.SendToBrowser);
	}

	protected override void OnClose (CloseEventArgs e) {}

	public void SendToBrowser (string message) {
		Send(message);
	}
}