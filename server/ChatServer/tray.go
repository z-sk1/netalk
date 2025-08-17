package main

import (
	_ "embed"
	"os"

	"github.com/getlantern/systray"
)

//go:embed assets/icon.ico
var iconData []byte

func setupTray() {
	systray.Run(onReady, onExit)
}

var consoleVisible = false

func onReady() {
	systray.SetIcon(iconData)
	systray.SetTitle("Netalk")
	systray.SetTooltip("Netalk - Chat Server Running")

	// add menu items
	mQuit := systray.AddMenuItem("Quit", "Stop the server and exit")
	mToggleConsole := systray.AddMenuItem("Show Console Window", "Show or hide the console window")

	go func() {
		for {
			select {
			case <-mToggleConsole.ClickedCh:
				consoleVisible = !consoleVisible
				showConsole(consoleVisible)

				if consoleVisible {
					mToggleConsole.SetTitle("Hide Console Window")
				} else {
					mToggleConsole.SetTitle("Show Console Window")
				}
			case <-mQuit.ClickedCh:
				systray.Quit()
				os.Exit(0)
				return
			}
		}
	}()
}

func onExit() {
	freeConsole.Call()
}
