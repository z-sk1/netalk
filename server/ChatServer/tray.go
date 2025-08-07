package main

import (
	_ "embed"
	"log"

	"github.com/getlantern/systray"
)

//go:embed assets\icon.ico
var iconData []byte

func setupTray() {
	systray.Run(onReady, onExit)
}

func onReady() {
	systray.SetIcon(iconData)
	systray.SetTitle("Netalk")
	systray.SetTooltip("Netalk - Chat Server Running")

	// add a menu item to quit the sever
	mQuit := systray.AddMenuItem("Quit", "Stop the server and exit")

	go func() {
		<-mQuit.ClickedCh
		systray.Quit()
	}()
}

func onExit() {
	log.Println("Tray icon exited.")
}
