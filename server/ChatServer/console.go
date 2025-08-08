package main

import (
	"syscall"
)

var (
	kernel32         = syscall.NewLazyDLL("kernel32.dll")
	user32           = syscall.NewLazyDLL("user32.dll")
	getConsoleWindow = kernel32.NewProc("GetConsoleWindow")
	showWindow       = user32.NewProc("ShowWindow")
)

const (
	SW_HIDE = 0
	SW_SHOW = 5
)

func getConsoleWindowHandle() uintptr {
	ret, _, _ := getConsoleWindow.Call()
	return ret
}

func showConsole(show bool) {
	hwnd := getConsoleWindowHandle()

	if hwnd == 0 {
		return
	}

	if show {
		showWindow.Call(SW_SHOW)
	} else {
		showWindow.Call(SW_HIDE)
	}
}
