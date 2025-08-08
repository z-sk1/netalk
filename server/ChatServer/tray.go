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

var consoleVisible = false

func onReady() {
	systray.SetIcon(iconData)
	systray.SetTitle("Netalk")
	systray.SetTooltip("Netalk - Chat Server Running")

	// add a menu items
	mQuit := systray.AddMenuItem("Quit", "Stop the server and exit")
	mToggleConsole := systray.AddMenuItem("Show Console Window", "Show or hide the console window")

	go func() {
		for {
			select {
			case <-mToggleConsole.ClickedCh:
				consoleVisible = !consoleVisible
				showConsole(consoleVisible)

				if consoleVisible {
					mToggleConsole.SetTitle("Show Console Window")
				} else {
					mToggleConsole.SetTitle("Hide Console Window")
				}
			case <-mQuit.ClickedCh:
				systray.Quit()
				return
			}
		}
	}()
}

func onExit() {
	log.Println("Tray icon exited.")
}
